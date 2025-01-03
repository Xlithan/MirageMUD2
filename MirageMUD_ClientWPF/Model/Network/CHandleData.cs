using Bindings;
using MirageMUD_ClientWPF.Model.Types;
using MirageMUD_ClientWPF.ViewModel;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;

namespace MirageMUD_ClientWPF.Model.Network
{
    internal class CHandleData
    {
        // Buffer to store the incoming data packet.
        public PacketBuffer buffer = new PacketBuffer();

        // Delegate for packet handlers that take byte arrays as input.
        private delegate void Packet_(byte[] data);

        // Dictionary to map packet numbers to their respective handler methods.
        private Dictionary<int, Packet_> Packets;

        // Initializes the packet handlers by mapping packet numbers to handler methods.
        public void InitialiseMessages()
        {
            Debug.WriteLine("Initializing messages...");

            // Initialize the Packets dictionary to store packet handlers.
            Packets = new Dictionary<int, Packet_>();

            // Add each packet number and its corresponding handler method to the dictionary
            // Each packet number is cast from the ServerPackets enum and mapped to a handler function
            Packets.Add((int)ServerPackets.SAlertMsg, HandleAlertMsg);
            Packets.Add((int)ServerPackets.SAllChars, HandleAllChars);
            Packets.Add((int)ServerPackets.SNewCharOk, HandleNewCharOk);
            Packets.Add((int)ServerPackets.SLogoutOk, HandleLogoutOk);
            Packets.Add((int)ServerPackets.SNewCharClasses, HandleNewCharClasses);
            Packets.Add((int)ServerPackets.SClassesData, HandleClassesData);
            Packets.Add((int)ServerPackets.SInGame, HandleInGame);
            Packets.Add((int)ServerPackets.SPlayerInv, HandlePlayerInv);
            Packets.Add((int)ServerPackets.SPlayerInvUpdate, HandlePlayerInvUpdate);
            Packets.Add((int)ServerPackets.SPlayerWornEq, HandlePlayerWornEq);
            Packets.Add((int)ServerPackets.SPlayerHp, HandlePlayerHp);
            Packets.Add((int)ServerPackets.SPlayerMp, HandlePlayerMp);
            Packets.Add((int)ServerPackets.SPlayerSp, HandlePlayerSp);
            Packets.Add((int)ServerPackets.SPlayerStamina, HandlePlayerStamina);
            Packets.Add((int)ServerPackets.SPlayerStats, HandlePlayerStats);
            Packets.Add((int)ServerPackets.SPlayerData, HandlePlayerData);
            Packets.Add((int)ServerPackets.SPlayerExp, HandlePlayerExp);
            Packets.Add((int)ServerPackets.SAttack, HandleAttack);
            Packets.Add((int)ServerPackets.SNpcAttack, HandleNpcAttack);
            Packets.Add((int)ServerPackets.SCheckForRoom, HandleCheckForRoom);
            Packets.Add((int)ServerPackets.SRoomData, HandleRoomData);
            Packets.Add((int)ServerPackets.SRoomItemData, HandleRoomItemData);
            Packets.Add((int)ServerPackets.SRoomNpcData, HandleRoomNpcData);
            Packets.Add((int)ServerPackets.SRoomDone, HandleRoomDone);
            Packets.Add((int)ServerPackets.SSayMsg, HandleSayMsg);
            Packets.Add((int)ServerPackets.SGlobalMsg, HandleGlobalMsg);
            Packets.Add((int)ServerPackets.SAdminMsg, HandleAdminMsg);
            Packets.Add((int)ServerPackets.SPlayerMsg, HandlePlayerMsg);
            Packets.Add((int)ServerPackets.SRoomMsg, HandleRoomMsg);
            Packets.Add((int)ServerPackets.SSpawnItem, HandleSpawnItem);
            Packets.Add((int)ServerPackets.SItemEditor, HandleItemEditor);
            Packets.Add((int)ServerPackets.SUpdateItem, HandleUpdateItem);
            Packets.Add((int)ServerPackets.SEditItem, HandleEditItem);
            Packets.Add((int)ServerPackets.SSpawnNpc, HandleSpawnNpc);
            Packets.Add((int)ServerPackets.SNpcDead, HandleNpcDead);
            Packets.Add((int)ServerPackets.SNpcEditor, HandleNpcEditor);
            Packets.Add((int)ServerPackets.SUpdateNpc, HandleUpdateNpc);
            Packets.Add((int)ServerPackets.SEditNpc, HandleEditNpc);
            Packets.Add((int)ServerPackets.SEditRoom, HandleEditRoom);
            Packets.Add((int)ServerPackets.SShopEditor, HandleShopEditor);
            Packets.Add((int)ServerPackets.SUpdateShop, HandleUpdateShop);
            Packets.Add((int)ServerPackets.SEditShop, HandleEditShop);
            Packets.Add((int)ServerPackets.SREditor, HandleRefresh);
            Packets.Add((int)ServerPackets.SSpellEditor, HandleSpellEditor);
            Packets.Add((int)ServerPackets.SUpdateSpell, HandleUpdateSpell);
            Packets.Add((int)ServerPackets.SEditSpell, HandleEditSpell);
            Packets.Add((int)ServerPackets.STrade, HandleTrade);
            Packets.Add((int)ServerPackets.SSpells, HandleSpells);
            Packets.Add((int)ServerPackets.SLeft, HandleLeft);
            Packets.Add((int)ServerPackets.SHighIndex, HandleHighIndex);
            Packets.Add((int)ServerPackets.SCastSpell, HandleSpellCast);
            Packets.Add((int)ServerPackets.SSendMaxes, HandleMaxes);
            Packets.Add((int)ServerPackets.SSync, HandleSync);
            Packets.Add((int)ServerPackets.SRoomRevs, HandleRoomRevs);
            Packets.Add((int)ServerPackets.SReRoll, HandleReRoll);
            Packets.Add((int)ServerPackets.SRaces, HandleRaces);
            Packets.Add((int)ServerPackets.SClasses, HandleClasses);
            Packets.Add((int)ServerPackets.SAccountCreated, HandleAccountCreated);
        }

        // Handles incoming messages by identifying the appropriate packet handler
        public void HandleMessages(byte[] data)
        {
            // Check if the incoming data is null or empty
            if (data == null || data.Length == 0)
            {
                Debug.WriteLine("Null or empty data.");
                return; // Exit if no data to process
            }

            // Check if packets dictionary is uninitialized
            if (Packets == null)
            {
                Debug.WriteLine("Packets are uninitialised.");
                return; // Exit if packet handlers are not initialized
            }

            int packetNum;

            // Using a new PacketBuffer to parse the incoming data
            using (PacketBuffer buffer = new PacketBuffer())
            {
                buffer.AddBytes(data); // Add incoming data to the buffer for processing
                packetNum = buffer.GetInteger(); // Extract the packet number (ID) from the buffer
            }

            // Check if the packet number has a corresponding handler in the dictionary
            if (Packets.TryGetValue(packetNum, out Packet_ packet))
            {
                packet.Invoke(data); // If found, invoke the handler for the packet with the data
            }
            else
            {
                // Log error if no handler is found for the packet number
                Debug.WriteLine(string.Format("No packet handler found for packet number: {0}", packetNum));
            }
        }

        // Handles the alert message and displays it in a MessageBox
        public void HandleAlertMsg(byte[] data)
        {
            // Using a new PacketBuffer to parse the incoming data
            using (PacketBuffer buffer = new PacketBuffer())
            {
                buffer.AddBytes(data); // Add the incoming data to the buffer
                buffer.GetInteger(); // Skip over the packet ID (not used here)
                string msg = buffer.GetString(); // Extract the alert message from the buffer

                // Display the alert message in a MessageBox
                MessageBox.Show(msg, "Alert", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        // Handles the "All Characters" message and updates the character selection view
        public void HandleAllChars(byte[] data)
        {
            // Using a new PacketBuffer to parse the incoming data
            using (PacketBuffer buffer = new PacketBuffer())
            {
                buffer.AddBytes(data); // Add the incoming data to the buffer
                buffer.GetInteger(); // Skip over the packet ID (not used here)
                Globals.Player.Login = buffer.GetString(); // Store the account name for the player

                // Update the UI on the main thread (as UI manipulation should be done on the main thread)
                Application.Current.Dispatcher.Invoke(() =>
                {
                    // Hide the LoginView and show the CharactersView
                    App.LoginViewInstance.Hide();
                    App.CharsViewInstance.Show();

                    // Access the DataContext (ViewModel) for character data binding
                    if (App.CharsViewInstance.DataContext is CharacterViewModel viewModel)
                    {
                        // Clear any existing characters from the ViewModel
                        viewModel.Characters.Clear();

                        // Loop through the character data (max characters)
                        for (int i = 0; i < Constants.MAX_CHARS; i++)
                        {
                            string charName = buffer.GetString(); // Character name
                            int charLevel = buffer.GetInteger(); // Character level
                            string charClass = buffer.GetString(); // Character class
                            string charRace = buffer.GetString(); // Character race
                            int charAvatar = buffer.GetInteger(); // Avatar ID
                            int charGender = buffer.GetInteger(); // Gender (0 = Male, 1 = Female)

                            string avatarPath;

                            // If the character name is empty, add an empty slot to the list
                            if (string.IsNullOrEmpty(charName))
                            {
                                viewModel.Characters.Add(new CharacterViewModel
                                {
                                    Name = "Empty Slot", // Placeholder text
                                    Level = string.Empty,
                                    ClassInfo = string.Empty,
                                    RaceInfo = string.Empty,
                                    Avatar = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "gfx", "avatars", "blank.bmp"),
                                    ID = i // Set the character ID (index)
                                });
                            }
                            else
                            {
                                // If the character has data, create a new CharacterViewModel for it
                                avatarPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "gfx", "avatars", "Players", charGender == 0 ? "Male" : "Female", charAvatar + ".bmp");

                                viewModel.Characters.Add(new CharacterViewModel
                                {
                                    Name = charName,
                                    Level = charLevel.ToString(),
                                    ClassInfo = charClass,
                                    RaceInfo = charRace,
                                    Avatar = avatarPath,
                                    ID = i // Set the character ID (index)
                                });
                            }
                        }

                        // Update character images for the UI (first 5 characters)
                        var image1 = new BitmapImage(new Uri(viewModel.Characters[0].Avatar, UriKind.Absolute));
                        App.CharsViewInstance.picChar1.Source = image1;

                        var image2 = new BitmapImage(new Uri(viewModel.Characters[1].Avatar, UriKind.Absolute));
                        App.CharsViewInstance.picChar2.Source = image2;

                        var image3 = new BitmapImage(new Uri(viewModel.Characters[2].Avatar, UriKind.Absolute));
                        App.CharsViewInstance.picChar3.Source = image3;

                        var image4 = new BitmapImage(new Uri(viewModel.Characters[3].Avatar, UriKind.Absolute));
                        App.CharsViewInstance.picChar4.Source = image4;

                        var image5 = new BitmapImage(new Uri(viewModel.Characters[4].Avatar, UriKind.Absolute));
                        App.CharsViewInstance.picChar5.Source = image5;
                    }
                });
            }
        }

        // Handles the "New Character OK" message and updates the character selection view
        public void HandleNewCharOk(byte[] data)
        {
            // Using a new PacketBuffer to parse the incoming data
            using (PacketBuffer buffer = new PacketBuffer())
            {
                buffer.AddBytes(data); // Add the incoming data to the buffer
                buffer.GetInteger(); // Skip over the packet ID (not used here)

                // Update the UI on the main thread (as UI manipulation should be done on the main thread)
                Application.Current.Dispatcher.Invoke(() =>
                {
                    // Hide the NewCharView (character creation view)
                    App.NewCharViewInstance.Hide();

                    // Show the CharactersView (character selection view)
                    App.CharsViewInstance.Show();

                    // Access the DataContext (ViewModel) for character data binding
                    if (App.CharsViewInstance.DataContext is CharacterViewModel viewModel)
                    {
                        // Clear any existing characters from the ViewModel
                        viewModel.Characters.Clear();

                        // Loop through the character data (max characters)
                        for (int i = 0; i < Constants.MAX_CHARS; i++)
                        {
                            // Extract character data from the buffer
                            string charName = buffer.GetString(); // Character name
                            int charLevel = buffer.GetInteger(); // Character level
                            string charClass = buffer.GetString(); // Character class
                            string charRace = buffer.GetString(); // Character race
                            int charAvatar = buffer.GetInteger(); // Avatar ID
                            int charGender = buffer.GetInteger(); // Gender (0 = Male, 1 = Female)

                            string avatarPath;

                            // If the character name is empty, add an empty slot to the list
                            if (string.IsNullOrEmpty(charName))
                            {
                                viewModel.Characters.Add(new CharacterViewModel
                                {
                                    Name = "Empty Slot", // Placeholder text for empty slots
                                    Level = string.Empty,
                                    ClassInfo = string.Empty,
                                    RaceInfo = string.Empty,
                                    Avatar = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "gfx", "avatars", "blank.bmp"), // Default blank avatar
                                    ID = i // Set the character ID (index)
                                });
                            }
                            else
                            {
                                // If the character has data, create a new CharacterViewModel for it
                                avatarPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "gfx", "avatars", "Players", charGender == 0 ? "Male" : "Female", charAvatar + ".bmp");

                                viewModel.Characters.Add(new CharacterViewModel
                                {
                                    Name = charName,
                                    Level = charLevel.ToString(),
                                    ClassInfo = charClass,
                                    RaceInfo = charRace,
                                    Avatar = avatarPath, // Set the avatar path
                                    ID = i // Set the character ID (index)
                                });
                            }
                        }

                        // Update character images for the UI (first 5 characters)
                        var image1 = new BitmapImage(new Uri(viewModel.Characters[0].Avatar, UriKind.Absolute));
                        App.CharsViewInstance.picChar1.Source = image1;

                        var image2 = new BitmapImage(new Uri(viewModel.Characters[1].Avatar, UriKind.Absolute));
                        App.CharsViewInstance.picChar2.Source = image2;

                        var image3 = new BitmapImage(new Uri(viewModel.Characters[2].Avatar, UriKind.Absolute));
                        App.CharsViewInstance.picChar3.Source = image3;

                        var image4 = new BitmapImage(new Uri(viewModel.Characters[3].Avatar, UriKind.Absolute));
                        App.CharsViewInstance.picChar4.Source = image4;

                        var image5 = new BitmapImage(new Uri(viewModel.Characters[4].Avatar, UriKind.Absolute));
                        App.CharsViewInstance.picChar5.Source = image5;
                    }
                });

                // Display a success message indicating that the account was created
                MessageBox.Show("Account was created!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        public void HandleLogoutOk(byte[] data)
        { }

        public void HandleNewCharClasses(byte[] data)
        { }

        public void HandleClassesData(byte[] data)
        { }

        public void HandleInGame(byte[] data)
        { }

        public void HandlePlayerInv(byte[] data)
        { }

        public void HandlePlayerInvUpdate(byte[] data)
        { }

        public void HandlePlayerWornEq(byte[] data)
        { }

        public void HandlePlayerHp(byte[] data)
        { }

        public void HandlePlayerMp(byte[] data)
        { }

        public void HandlePlayerSp(byte[] data)
        { }

        public void HandlePlayerStamina(byte[] data)
        { }

        public void HandlePlayerStats(byte[] data)
        { }

        public void HandlePlayerData(byte[] data)
        { }

        public void HandlePlayerExp(byte[] data)
        { }

        public void HandleAttack(byte[] data)
        { }

        public void HandleNpcAttack(byte[] data)
        { }

        public void HandleCheckForRoom(byte[] data)
        { }

        public void HandleRoomData(byte[] data)
        { }

        public void HandleRoomItemData(byte[] data)
        { }

        public void HandleRoomNpcData(byte[] data)
        { }

        public void HandleRoomDone(byte[] data)
        { }

        public void HandleSayMsg(byte[] data)
        { }

        public void HandleGlobalMsg(byte[] data)
        { }

        public void HandleAdminMsg(byte[] data)
        { }

        public void HandlePlayerMsg(byte[] data)
        { }

        public void HandleRoomMsg(byte[] data)
        { }

        public void HandleSpawnItem(byte[] data)
        { }

        public void HandleItemEditor(byte[] data)
        { }

        public void HandleUpdateItem(byte[] data)
        { }

        public void HandleEditItem(byte[] data)
        { }

        public void HandleSpawnNpc(byte[] data)
        { }

        public void HandleNpcDead(byte[] data)
        { }

        public void HandleNpcEditor(byte[] data)
        { }

        public void HandleUpdateNpc(byte[] data)
        { }

        public void HandleEditNpc(byte[] data)
        { }

        public void HandleEditRoom(byte[] data)
        { }

        public void HandleShopEditor(byte[] data)
        { }

        public void HandleUpdateShop(byte[] data)
        { }

        public void HandleEditShop(byte[] data)
        { }

        public void HandleRefresh(byte[] data)
        { }

        public void HandleSpellEditor(byte[] data)
        { }

        public void HandleUpdateSpell(byte[] data)
        { }

        public void HandleEditSpell(byte[] data)
        { }

        public void HandleTrade(byte[] data)
        { }

        public void HandleSpells(byte[] data)
        { }

        public void HandleLeft(byte[] data)
        { }

        public void HandleHighIndex(byte[] data)
        { }

        public void HandleSpellCast(byte[] data)
        { }

        public void HandleMaxes(byte[] data)
        { }

        public void HandleSync(byte[] data)
        { }

        public void HandleRoomRevs(byte[] data)
        { }

        // Handles the "ReRoll" message, updating character attributes
        public void HandleReRoll(byte[] data)
        {
            // Using a new PacketBuffer to parse the incoming data
            using (PacketBuffer buffer = new PacketBuffer())
            {
                buffer.AddBytes(data); // Add the incoming data to the buffer
                buffer.GetInteger(); // Skip over the packet ID (not used here)

                // Update the UI on the main thread (UI manipulation should be done on the main thread)
                Application.Current.Dispatcher.Invoke(() =>
                {
                    // Set the text values for character attributes from the buffer
                    App.NewCharViewInstance.lblStrength.Text = buffer.GetInteger().ToString(); // Strength attribute
                    App.NewCharViewInstance.lblIntelligence.Text = buffer.GetInteger().ToString(); // Intelligence attribute
                    App.NewCharViewInstance.lblDexterity.Text = buffer.GetInteger().ToString(); // Dexterity attribute
                    App.NewCharViewInstance.lblConstitution.Text = buffer.GetInteger().ToString(); // Constitution attribute
                    App.NewCharViewInstance.lblWisdom.Text = buffer.GetInteger().ToString(); // Wisdom attribute
                    App.NewCharViewInstance.lblCharisma.Text = buffer.GetInteger().ToString(); // Charisma attribute
                });
            }
        }

        public void HandleRaces(byte[] data)
        { }

        public void HandleClasses(byte[] data)
        { }

        // Handles the "Account Created" message, clearing input fields and displaying a success message
        public void HandleAccountCreated(byte[] data)
        {
            // Using a new PacketBuffer to parse the incoming data
            using (PacketBuffer buffer = new PacketBuffer())
            {
                buffer.AddBytes(data); // Add the incoming data to the buffer
                buffer.GetInteger(); // Skip over the packet ID (not used here)

                // Update the UI on the main thread (UI manipulation should be done on the main thread)
                Application.Current.Dispatcher.Invoke(() =>
                {
                    // Clear the account creation input fields after account is created
                    App.NewAccViewInstance.txtUsername.Text = string.Empty; // Clear username field
                    App.NewAccViewInstance.txtPassword.Password = string.Empty; // Clear password field
                    App.NewAccViewInstance.txtPasswordConfirm.Password = string.Empty; // Clear password confirmation field
                });

                // Show a message box indicating the account was successfully created
                MessageBox.Show("Account was created!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}