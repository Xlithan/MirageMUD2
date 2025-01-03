using Bindings;
using MirageMUD_Server.Storage;
using System.Security.Cryptography;
using System.Text;

namespace MirageMUD_Server.Network
{
    internal class SHandleData
    {
        private delegate void Packet_(int Index, byte[] data); // Delegate to handle packet processing

        private Dictionary<int, Packet_> Packets; // Dictionary to store packet handlers
        private Database db = new Database(); // Database instance to interact with stored data
        private ServerTCP serverTCP;  // Instance of ClientTCP for network communication

        public SHandleData()
        {
            serverTCP = ServerTCP.Instance;
        }

        public void InitialiseMessages()
        {
            Packets = new Dictionary<int, Packet_>(); // Initialize the dictionary for packet handlers

            // Map each packet ID to its respective handler method
            Packets.Add((int)ClientPackets.CGetClasses, HandleGetClasses);
            Packets.Add((int)ClientPackets.CNewAccount, HandleNewAccount);
            Packets.Add((int)ClientPackets.CDelAccount, HandleDelAccount);
            Packets.Add((int)ClientPackets.CLogin, HandleLogin);
            Packets.Add((int)ClientPackets.CLogout, HandleLogout);
            Packets.Add((int)ClientPackets.CAddChar, HandleAddChar);
            Packets.Add((int)ClientPackets.CDelChar, HandleDelChar);
            Packets.Add((int)ClientPackets.CUseChar, HandleUseChar);
            Packets.Add((int)ClientPackets.CSayMsg, HandleSayMsg);
            Packets.Add((int)ClientPackets.CEmoteMsg, HandleEmoteMsg);
            Packets.Add((int)ClientPackets.CBroadcastMsg, HandleBroadcastMsg);
            Packets.Add((int)ClientPackets.CGlobalMsg, HandleGlobalMsg);
            Packets.Add((int)ClientPackets.CAdminMsg, HandleAdminMsg);
            Packets.Add((int)ClientPackets.CPlayerMsg, HandlePlayerMsg);
            Packets.Add((int)ClientPackets.CPlayerMove, HandlePlayerMove);
            Packets.Add((int)ClientPackets.CPlayerDir, HandlePlayerDir);
            Packets.Add((int)ClientPackets.CUseItem, HandleUseItem);
            Packets.Add((int)ClientPackets.CAttack, HandleAttack);
            Packets.Add((int)ClientPackets.CUseStatPoint, HandleUseStatPoint);
            Packets.Add((int)ClientPackets.CPlayerInfoRequest, HandlePlayerInfoRequest);
            Packets.Add((int)ClientPackets.CWarpMeTo, HandleWarpMeTo);
            Packets.Add((int)ClientPackets.CWarpToMe, HandleWarpToMe);
            Packets.Add((int)ClientPackets.CWarpTo, HandleWarpTo);
            Packets.Add((int)ClientPackets.CSetAvatar, HandleSetAvatar);
            Packets.Add((int)ClientPackets.CGetStats, HandleGetStats);
            Packets.Add((int)ClientPackets.CRequestNewRoom, HandleRequestNewRoom);
            Packets.Add((int)ClientPackets.CRoomData, HandleRoomData);
            Packets.Add((int)ClientPackets.CNeedRoom, HandleNeedRoom);
            Packets.Add((int)ClientPackets.CRoomGetItem, HandleRoomGetItem);
            Packets.Add((int)ClientPackets.CRoomDropItem, HandleRoomDropItem);
            Packets.Add((int)ClientPackets.CRoomRespawn, HandleRoomRespawn);
            Packets.Add((int)ClientPackets.CRoomReport, HandleRoomReport);
            Packets.Add((int)ClientPackets.CKickPlayer, HandleKickPlayer);
            Packets.Add((int)ClientPackets.CBanList, HandleBanList);
            Packets.Add((int)ClientPackets.CBanDestroy, HandleBanDestroy);
            Packets.Add((int)ClientPackets.CBanPlayer, HandleBanPlayer);
            Packets.Add((int)ClientPackets.CRequestEditRoom, HandleRequestEditRoom);
            Packets.Add((int)ClientPackets.CRequestEditItem, HandleRequestEditItem);
            Packets.Add((int)ClientPackets.CEditItem, HandleEditItem);
            Packets.Add((int)ClientPackets.CSaveItem, HandleSaveItem);
            Packets.Add((int)ClientPackets.CRequestEditNpc, HandleRequestEditNpc);
            Packets.Add((int)ClientPackets.CEditNpc, HandleEditNpc);
            Packets.Add((int)ClientPackets.CSaveNpc, HandleSaveNpc);
            Packets.Add((int)ClientPackets.CRequestEditShop, HandleRequestEditShop);
            Packets.Add((int)ClientPackets.CEditShop, HandleEditShop);
            Packets.Add((int)ClientPackets.CSaveShop, HandleSaveShop);
            Packets.Add((int)ClientPackets.CRequestEditSpell, HandleRequestEditSpell);
            Packets.Add((int)ClientPackets.CEditSpell, HandleEditSpell);
            Packets.Add((int)ClientPackets.CSaveSpell, HandleSaveSpell);
            Packets.Add((int)ClientPackets.CDelete, HandleDelete);
            Packets.Add((int)ClientPackets.CSetAccess, HandleSetAccess);
            Packets.Add((int)ClientPackets.CWhosOnline, HandleWhosOnline);
            Packets.Add((int)ClientPackets.CSetMotd, HandleSetMotd);
            Packets.Add((int)ClientPackets.CTrade, HandleTrade);
            Packets.Add((int)ClientPackets.CTradeRequest, HandleTradeRequest);
            Packets.Add((int)ClientPackets.CFixItem, HandleFixItem);
            Packets.Add((int)ClientPackets.CSearch, HandleSearch);
            Packets.Add((int)ClientPackets.CParty, HandleParty);
            Packets.Add((int)ClientPackets.CJoinParty, HandleJoinParty);
            Packets.Add((int)ClientPackets.CLeaveParty, HandleLeaveParty);
            Packets.Add((int)ClientPackets.CSpells, HandleSpells);
            Packets.Add((int)ClientPackets.CCast, HandleCast);
            Packets.Add((int)ClientPackets.CQuit, HandleQuit);
            Packets.Add((int)ClientPackets.CSync, HandleSync);
            Packets.Add((int)ClientPackets.CRoomReqs, HandleRoomReqs);
            Packets.Add((int)ClientPackets.CSleepInn, HandleSleepInn);
            Packets.Add((int)ClientPackets.CRemoveFromGuild, HandleRemoveFromGuild);
            Packets.Add((int)ClientPackets.CCreateGuild, HandleCreateGuild);
            Packets.Add((int)ClientPackets.CInviteGuild, HandleInviteGuild);
            Packets.Add((int)ClientPackets.CKickGuild, HandleKickGuild);
            Packets.Add((int)ClientPackets.CGuildPromote, HandleGuildPromote);
            Packets.Add((int)ClientPackets.CLeaveGuild, HandleLeaveGuild);
            Packets.Add((int)ClientPackets.CReRoll, HandleReRoll);
        }

        public void HandleMessages(int Index, byte[] data)
        {
            // Check if the incoming data is null or empty
            if (data == null || data.Length == 0)
            {
                Console.WriteLine(TranslationManager.Instance.GetTranslation("errors.null_or_empty_data"));
                return; // Return if data is invalid
            }

            // Check if packets dictionary is uninitialized
            if (Packets == null)
            {
                Console.WriteLine(TranslationManager.Instance.GetTranslation("errors.uninitialized_packets"));
                return; // Return if packets dictionary is not initialized
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
                packet.Invoke(Index, data); // Invoke the handler with the given index and data
            }
            else
            {
                // Log error if no handler is found for the packet
                Console.WriteLine(string.Format(TranslationManager.Instance.GetTranslation("errors.no_handler"), packetNum));
            }
        }

        private void HandleGetClasses(int Index, byte[] data)
        { }

        private void HandleNewAccount(int Index, byte[] data)
        {
            using (PacketBuffer buffer = new PacketBuffer())
            {
                buffer.AddBytes(data); // Add data to buffer
                buffer.GetInteger(); // Skip packet ID as it's not needed here
                string username = buffer.GetString(); // Extract username from buffer
                string password = buffer.GetString(); // Extract password from buffer

                // Generate a random salt (16 bytes)
                byte[] salt = new byte[16];
                using (var rng = new RNGCryptoServiceProvider())
                {
                    rng.GetBytes(salt); // Generate random salt for password hashing
                }

                // Combine password and salt to prepare for hashing
                string passwordWithSalt = password + Convert.ToBase64String(salt);

                // Hash the password + salt using SHA256 for security
                using (SHA256 sha256 = SHA256.Create())
                {
                    byte[] hashedPassword = sha256.ComputeHash(Encoding.UTF8.GetBytes(passwordWithSalt));

                    // Check if the account already exists in the database
                    if (!db.AccountExist(username))
                    {
                        // Store the hashed password and salt in the database
                        db.AddAccount(Index, username, Convert.ToBase64String(hashedPassword), Convert.ToBase64String(salt));
                        Console.WriteLine(TranslationManager.Instance.GetTranslation("user.account_created"), username);
                        serverTCP.SendAccountCreated(Index); // Notify the client that the account is created

                        // Clear player data from the database and log the player out so that we can log in with the new account.
                        db.UnloadPlayer(Index);
                    }
                    else
                    {
                        // If account already exists, send an error message
                        serverTCP.AlertMsg(Index, "Username already exists.");
                    }
                }
            }
        }

        private void HandleDelAccount(int Index, byte[] data)
        { }

        // Method to handle login
        private void HandleLogin(int Index, byte[] data)
        {
            using (PacketBuffer buffer = new PacketBuffer())
            {
                buffer.AddBytes(data); // Add data to buffer
                buffer.GetInteger(); // Skip packet ID as it's not needed here
                string username = buffer.GetString(); // Extract username from buffer
                string password = buffer.GetString(); // Extract password from buffer

                // Check if the username exists in the database
                if (db.AccountExist(username))
                {
                    // If the client slot already has a non-null socket (i.e., user is already logged in)
                    if (serverTCP.IsLoggedIn(username))
                    {
                        // Prevent duplicate account logins and notify the client
                        serverTCP.AlertMsg(Index, "This account is already logged in.");
                    }
                    else
                    {
                        // Retrieve the hashed password and salt from the database
                        string storedHashedPassword = db.GetHashedPassword(username);
                        string storedSalt = db.GetSalt(username);

                        // Combine the input password with the stored salt
                        string passwordWithSalt = password + storedSalt;

                        // Hash the input password with salt
                        using (SHA256 sha256 = SHA256.Create())
                        {
                            byte[] inputHashedPassword = sha256.ComputeHash(Encoding.UTF8.GetBytes(passwordWithSalt));

                            // Compare the hashed password with the stored hashed password
                            if (Convert.ToBase64String(inputHashedPassword) == storedHashedPassword)
                            {
                                // If the password matches, load player data and send characters to the client
                                db.LoadPlayer(Index, username);
                                serverTCP.SendChars(Index);
                                // SendMaxes(); // (commented-out line for sending maxes, not currently used)
                                Console.WriteLine(TranslationManager.Instance.GetTranslation("user.logged_in"), username, ServerTCP.Clients[Index].IP);
                            }
                            else
                            {
                                // Incorrect password, send an error message
                                serverTCP.AlertMsg(Index, "Incorrect password for this account.");
                            }
                        }
                    }
                }
                else
                {
                    // Username does not exist in the database, send an error message
                    serverTCP.AlertMsg(Index, "Account does not exist.");
                }
            }
        }

        private void HandleLogout(int Index, byte[] data)
        {
            using (PacketBuffer buffer = new PacketBuffer())
            {
                buffer.AddBytes(data); // Add data to buffer
                buffer.GetInteger(); // Skip packet ID as it's not needed here

                // Clear player data from the database and log the player out
                db.UnloadPlayer(Index);
            }
        }

        private void HandleAddChar(int Index, byte[] data)
        {
            using (PacketBuffer buffer = new PacketBuffer())
            {
                buffer.AddBytes(data); // Add incoming data to buffer
                buffer.GetInteger(); // Skip the packet ID as it's not necessary for this operation
                string username = buffer.GetString(); // Extract the username from the buffer
                string charName = buffer.GetString(); // Extract the character name from the buffer
                int charGender = buffer.GetInteger(); // Extract the gender of the character
                int charRace = buffer.GetInteger(); // Extract the race of the character
                int charClass = buffer.GetInteger(); // Extract the class of the character
                int charAvatar = buffer.GetInteger(); // Extract the avatar ID for the character
                int charNum = buffer.GetInteger(); // Extract the unique character ID

                // Check if the username exists in the database
                if (db.AccountExist(username))
                {
                    // Check if the character already exists
                    if (db.CharacterExist(charName))
                    {
                        // If the character name already exists, send an error message
                        serverTCP.AlertMsg(Index, "This character name already exists.");
                    }
                    else
                    {
                        // If the character name doesn't exist, add the new character to the database
                        db.AddChar(Index, charNum, charName, charGender, charRace, charClass, charAvatar);
                        // Notify the client that the character has been created
                        serverTCP.SendCharCreated(Index);
                        Console.WriteLine(TranslationManager.Instance.GetTranslation("user.char_created"), charName, charNum);
                    }
                }
                else
                {
                    // If the account doesn't exist, send an error message
                    serverTCP.AlertMsg(Index, "Account does not exist.");
                }
            }
        }

        private void HandleDelChar(int Index, byte[] data)
        { }

        private void HandleUseChar(int Index, byte[] data)
        { }

        private void HandleSayMsg(int Index, byte[] data)
        { }

        private void HandleEmoteMsg(int Index, byte[] data)
        { }

        private void HandleBroadcastMsg(int Index, byte[] data)
        { }

        private void HandleGlobalMsg(int Index, byte[] data)
        { }

        private void HandleAdminMsg(int Index, byte[] data)
        { }

        private void HandlePlayerMsg(int Index, byte[] data)
        { }

        private void HandlePlayerMove(int Index, byte[] data)
        { }

        private void HandlePlayerDir(int Index, byte[] data)
        { }

        private void HandleUseItem(int Index, byte[] data)
        { }

        private void HandleAttack(int Index, byte[] data)
        { }

        private void HandleUseStatPoint(int Index, byte[] data)
        { }

        private void HandlePlayerInfoRequest(int Index, byte[] data)
        { }

        private void HandleWarpMeTo(int Index, byte[] data)
        { }

        private void HandleWarpToMe(int Index, byte[] data)
        { }

        private void HandleWarpTo(int Index, byte[] data)
        { }

        private void HandleSetAvatar(int Index, byte[] data)
        { }

        private void HandleGetStats(int Index, byte[] data)
        { }

        private void HandleRequestNewRoom(int Index, byte[] data)
        { }

        private void HandleRoomData(int Index, byte[] data)
        { }

        private void HandleNeedRoom(int Index, byte[] data)
        { }

        private void HandleRoomGetItem(int Index, byte[] data)
        { }

        private void HandleRoomDropItem(int Index, byte[] data)
        { }

        private void HandleRoomRespawn(int Index, byte[] data)
        { }

        private void HandleRoomReport(int Index, byte[] data)
        { }

        private void HandleKickPlayer(int Index, byte[] data)
        { }

        private void HandleBanList(int Index, byte[] data)
        { }

        private void HandleBanDestroy(int Index, byte[] data)
        { }

        private void HandleBanPlayer(int Index, byte[] data)
        { }

        private void HandleRequestEditRoom(int Index, byte[] data)
        { }

        private void HandleRequestEditItem(int Index, byte[] data)
        { }

        private void HandleEditItem(int Index, byte[] data)
        { }

        private void HandleSaveItem(int Index, byte[] data)
        { }

        private void HandleRequestEditNpc(int Index, byte[] data)
        { }

        private void HandleEditNpc(int Index, byte[] data)
        { }

        private void HandleSaveNpc(int Index, byte[] data)
        { }

        private void HandleRequestEditShop(int Index, byte[] data)
        { }

        private void HandleEditShop(int Index, byte[] data)
        { }

        private void HandleSaveShop(int Index, byte[] data)
        { }

        private void HandleRequestEditSpell(int Index, byte[] data)
        { }

        private void HandleEditSpell(int Index, byte[] data)
        { }

        private void HandleSaveSpell(int Index, byte[] data)
        { }

        private void HandleDelete(int Index, byte[] data)
        { }

        private void HandleSetAccess(int Index, byte[] data)
        { }

        private void HandleWhosOnline(int Index, byte[] data)
        { }

        private void HandleSetMotd(int Index, byte[] data)
        { }

        private void HandleTrade(int Index, byte[] data)
        { }

        private void HandleTradeRequest(int Index, byte[] data)
        { }

        private void HandleFixItem(int Index, byte[] data)
        { }

        private void HandleSearch(int Index, byte[] data)
        { }

        private void HandleParty(int Index, byte[] data)
        { }

        private void HandleJoinParty(int Index, byte[] data)
        { }

        private void HandleLeaveParty(int Index, byte[] data)
        { }

        private void HandleSpells(int Index, byte[] data)
        { }

        private void HandleCast(int Index, byte[] data)
        { }

        private void HandleQuit(int Index, byte[] data)
        { }

        private void HandleSync(int Index, byte[] data)
        { }

        private void HandleRoomReqs(int Index, byte[] data)
        { }

        private void HandleSleepInn(int Index, byte[] data)
        { }

        private void HandleRemoveFromGuild(int Index, byte[] data)
        { }

        private void HandleCreateGuild(int Index, byte[] data)
        { }

        private void HandleInviteGuild(int Index, byte[] data)
        { }

        private void HandleKickGuild(int Index, byte[] data)
        { }

        private void HandleGuildPromote(int Index, byte[] data)
        { }

        private void HandleLeaveGuild(int Index, byte[] data)
        { }

        private void HandleReRoll(int Index, byte[] data)
        {
            serverTCP.SendReRoll(Index); // Sends the reroll request to the server for the specified player
        }
    }
}