using Bindings;
using MirageMUD_ClientWPF.View;
using MirageMUD_ClientWPF.ViewModel;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media.Imaging;

namespace MirageMUD_ClientWPF.Model.Network
{
    internal class CHandleData
    {
        // Buffer to store the incoming data packet.
        public PacketBuffer buffer = new PacketBuffer();

        // Delegate for packet handlers that take byte arrays as input.
        private delegate void Packet_(byte[] data);

        // Dictionary to map packet numbers to their respective handlers.
        private Dictionary<int, Packet_> Packets;

        // Initializes the packet handlers by mapping packet numbers to handler methods.
        public void InitialiseMessages()
        {
            Debug.WriteLine("Initializing messages...");
            Packets = new Dictionary<int, Packet_>();

            // Add each packet number and its corresponding handler method to the dictionary
            Packets.Add((int)ServerPackets.SAlertMsg, HandleAlertMsg);
            Packets.Add((int)ServerPackets.SAllChars, HandleAllChars);
            Packets.Add((int)ServerPackets.SLoginOk, HandleLoginOk);
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
                return;
            }

            // Check if packets dictionary is uninitialized
            if (Packets == null)
            {
                Debug.WriteLine("Packets are uninitialised.");
                return;
            }

            int packetNum;
            using (PacketBuffer buffer = new PacketBuffer())
            {
                buffer.AddBytes(data); // Add data to buffer
                packetNum = buffer.GetInteger(); // Extract the packet ID from the buffer
            }

            // Check if the packet number has a handler and invoke it if found
            if (Packets.TryGetValue(packetNum, out Packet_ packet))
            {
                packet.Invoke(data); // Invoke the handler with the given index and data
            }
            else
            {
                // Log error if no handler is found for the packet
                Debug.WriteLine(string.Format("No packet handler found for packet number: {0}", packetNum));
            }
        }

        // Below methods are the packet handlers for various server messages.
        // Each handler method is a placeholder for now and can be implemented later.

        public void HandleAlertMsg(byte[] data)
        {
            using (PacketBuffer buffer = new PacketBuffer())
            {
                buffer.AddBytes(data); // Add data to buffer
                buffer.GetInteger(); // Skip packet ID
                string msg = buffer.GetString(); // Extract msg

                //frmMenu.Default.RunOnUIThread(() => frmMenu.Default.ResetMenu());
                MessageBox.Show(msg, "Alert", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }
        public void HandleAllChars(byte[] data)
        {
            using (PacketBuffer buffer = new PacketBuffer())
            {
                buffer.AddBytes(data);
                buffer.GetInteger(); // Skip packet ID
                buffer.GetString(); // Skip login string (We may need it later)

                Application.Current.Dispatcher.Invoke(() =>
                {
                    App.LoginViewInstance.Hide();

                    // Show the CharactersView
                    App.CharsViewInstance.Show();

                    // Access the DataContext (ViewModel)
                    if (App.CharsViewInstance.DataContext is CharacterViewModel viewModel)
                    {
                        // Clear any existing characters
                        viewModel.Characters.Clear();

                        for (int i = 0; i < Constants.MAX_CHARS; i++)
                        {
                            string charName = buffer.GetString();
                            byte charLevel = buffer.GetByte();
                            string charClass = buffer.GetString();
                            string charRace = buffer.GetString();
                            int charAvatar = buffer.GetInteger();
                            byte charGender = buffer.GetByte();

                            string avatarPath;
                            if (string.IsNullOrEmpty(charName))
                            {
                                viewModel.Characters.Add(new CharacterViewModel
                                {
                                    Name = "Empty Slot",
                                    Level = string.Empty,
                                    ClassInfo = string.Empty,
                                    RaceInfo = string.Empty,
                                    Avatar = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "gfx", "avatars", "blank.bmp")
                                });
                            }
                            else
                            {
                                // Example: Populate with actual data (Level and ClassInfo from buffer)
                                //int level = buffer.GetInteger();
                                //string classInfo = buffer.GetString();
                                avatarPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "gfx", "avatars", "Players", charGender == 0 ? "Male" : "Female", charAvatar + ".bmp");

                                viewModel.Characters.Add(new CharacterViewModel
                                {
                                    Name = charName,
                                    Level = charLevel.ToString(),
                                    ClassInfo = charClass,
                                    RaceInfo = charRace,
                                    Avatar = avatarPath
                                });
                            }
                        }
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
        public void HandleLoginOk(byte[] data) { }
        public void HandleLogoutOk(byte[] data) { }
        public void HandleAccountCreated(byte[] data)
        {
            using (PacketBuffer buffer = new PacketBuffer())
            {
                buffer.AddBytes(data); // Add data to buffer
                buffer.GetInteger(); // Skip packet ID

                Application.Current.Dispatcher.Invoke(() =>
                {
                    App.NewAccViewInstance.txtUsername.Text = string.Empty;
                    App.NewAccViewInstance.txtPassword.Password = string.Empty;
                    App.NewAccViewInstance.txtPasswordConfirm.Password = string.Empty;
                });

                MessageBox.Show("Account was created!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
        public void HandleNewCharClasses(byte[] data) { }
        public void HandleClassesData(byte[] data) { }
        public void HandleInGame(byte[] data) { }
        public void HandlePlayerInv(byte[] data) { }
        public void HandlePlayerInvUpdate(byte[] data) { }
        public void HandlePlayerWornEq(byte[] data) { }
        public void HandlePlayerHp(byte[] data) { }
        public void HandlePlayerMp(byte[] data) { }
        public void HandlePlayerSp(byte[] data) { }
        public void HandlePlayerStamina(byte[] data) { }
        public void HandlePlayerStats(byte[] data) { }
        public void HandlePlayerData(byte[] data) { }
        public void HandlePlayerExp(byte[] data) { }
        public void HandleAttack(byte[] data) { }
        public void HandleNpcAttack(byte[] data) { }
        public void HandleCheckForRoom(byte[] data) { }
        public void HandleRoomData(byte[] data) { }
        public void HandleRoomItemData(byte[] data) { }
        public void HandleRoomNpcData(byte[] data) { }
        public void HandleRoomDone(byte[] data) { }
        public void HandleSayMsg(byte[] data) { }
        public void HandleGlobalMsg(byte[] data) { }
        public void HandleAdminMsg(byte[] data) { }
        public void HandlePlayerMsg(byte[] data) { }
        public void HandleRoomMsg(byte[] data) { }
        public void HandleSpawnItem(byte[] data) { }
        public void HandleItemEditor(byte[] data) { }
        public void HandleUpdateItem(byte[] data) { }
        public void HandleEditItem(byte[] data) { }
        public void HandleSpawnNpc(byte[] data) { }
        public void HandleNpcDead(byte[] data) { }
        public void HandleNpcEditor(byte[] data) { }
        public void HandleUpdateNpc(byte[] data) { }
        public void HandleEditNpc(byte[] data) { }
        public void HandleEditRoom(byte[] data) { }
        public void HandleShopEditor(byte[] data) { }
        public void HandleUpdateShop(byte[] data) { }
        public void HandleEditShop(byte[] data) { }
        public void HandleRefresh(byte[] data) { }
        public void HandleSpellEditor(byte[] data) { }
        public void HandleUpdateSpell(byte[] data) { }
        public void HandleEditSpell(byte[] data) { }
        public void HandleTrade(byte[] data) { }
        public void HandleSpells(byte[] data) { }
        public void HandleLeft(byte[] data) { }
        public void HandleHighIndex(byte[] data) { }
        public void HandleSpellCast(byte[] data) { }
        public void HandleMaxes(byte[] data) { }
        public void HandleSync(byte[] data) { }
        public void HandleRoomRevs(byte[] data) { }
        public void HandleReRoll(byte[] data)
        {
            using (PacketBuffer buffer = new PacketBuffer())
            {
                buffer.AddBytes(data); // Add data to buffer
                buffer.GetInteger(); // Skip packet ID

                Application.Current.Dispatcher.Invoke(() =>
                {
                    // Set the text values
                    App.NewCharViewInstance.lblStrength.Text = buffer.GetInteger().ToString();
                    App.NewCharViewInstance.lblIntelligence.Text = buffer.GetInteger().ToString();
                    App.NewCharViewInstance.lblDexterity.Text = buffer.GetInteger().ToString();
                    App.NewCharViewInstance.lblConstitution.Text = buffer.GetInteger().ToString();
                    App.NewCharViewInstance.lblWisdom.Text = buffer.GetInteger().ToString();
                    App.NewCharViewInstance.lblCharisma.Text = buffer.GetInteger().ToString();
                });
            }
        }
        public void HandleRaces(byte[] data) { }
        public void HandleClasses(byte[] data) { }
    }
}