using Bindings;
using MirageMUD_Server.Storage;
using System.Security.Cryptography;
using MirageMUD_Server.Security;
using System.Text;

namespace MirageMUD_Server.Network
{
    internal class SHandleData
    {
        private delegate void Packet_(int Index, byte[] data); // Delegate to handle packet processing

        private Dictionary<int, Packet_> Packets; // Dictionary to store packet handlers
        private Database db = new Database(); // Database instance to interact with stored data
        private ServerTCP serverTCP;  // Instance of ClientTCP for network communication

        private readonly RateLimiter _rateLimiter = new();
        private string ClientKey(int index)
        {
            var ip = ServerTCP.Clients[index].IP;
            return string.IsNullOrEmpty(ip) ? $"idx:{index}" : ip;
        }

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
            Packets.Add((int)ClientPackets.CCommand, HandleCommand);
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

        private void HandleNewAccount(int index, byte[] data)
        {
            using var buffer = new PacketBuffer();
            buffer.AddBytes(data);
            buffer.GetInteger();
            string username = buffer.GetString();
            string password = buffer.GetString();

            var key = ClientKey(index);
            if (_rateLimiter.IsBlocked(key))
            {
                serverTCP.AlertMsg(index, "account_create_failed");
                return;
            }

            if (!Username.IsValid(username))
            {
                serverTCP.AlertMsg(index, "account_create_failed");
                _rateLimiter.Fail(key);
                return;
            }
            username = Username.Normalize(username);

            if (db.AccountExist(username))
            {
                serverTCP.AlertMsg(index, "account_create_failed");
                _rateLimiter.Fail(key);
                return;
            }

            // Generate random salt
            string salt = Convert.ToBase64String(RandomNumberGenerator.GetBytes(16));

            // Hash password+salt
            string passwordWithSalt = password + salt;
            byte[] hashBytes;
            using (SHA256 sha256 = SHA256.Create())
            {
                hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(passwordWithSalt));
            }
            string hashedPassword = Convert.ToBase64String(hashBytes);

            // Save account
            db.AddAccount(index, username, hashedPassword, salt);

            _rateLimiter.Success(key);
            serverTCP.SendAccountCreated(index);
        }

        private void HandleDelAccount(int Index, byte[] data)
        { }

        // Method to handle login
        private void HandleLogin(int Index, byte[] data)
        {
            using (PacketBuffer buffer = new PacketBuffer())
            {
                buffer.AddBytes(data);            // Add data to buffer
                buffer.GetInteger();              // Skip packet ID
                string username = buffer.GetString();
                string password = buffer.GetString();

                // Normalize username (trim + case-insensitive handling if desired)
                username = username.Trim();
                // If you want case-insensitive accounts everywhere, uncomment:
                // username = username.ToLowerInvariant();

                // Check account exists
                if (!db.AccountExist(username))
                {
                    // Generic and existing key so UI stays the same
                    serverTCP.AlertMsg(Index, "account_notexist");
                    return;
                }

                // Prevent duplicate login
                if (serverTCP.IsLoggedIn(username))
                {
                    serverTCP.AlertMsg(Index, "account_loggedin");
                    return;
                }

                // Retrieve stored hash & salt (legacy format)
                string storedHashedPassword = db.GetHashedPassword(username);
                string storedSalt = db.GetSalt(username);

                if (string.IsNullOrEmpty(storedHashedPassword) || string.IsNullOrEmpty(storedSalt))
                {
                    serverTCP.AlertMsg(Index, "incorrect_password");
                    return;
                }

                // Compute SHA256(password + salt)
                byte[] inputHashBytes;
                using (SHA256 sha256 = SHA256.Create())
                {
                    string passwordWithSalt = password + storedSalt;
                    inputHashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(passwordWithSalt));
                }

                // Compare in constant time to avoid timing leaks
                try
                {
                    byte[] storedHashBytes = Convert.FromBase64String(storedHashedPassword);
                    bool match = CryptographicOperations.FixedTimeEquals(inputHashBytes, storedHashBytes);

                    if (match)
                    {
                        // TODO: (Optional) On successful login, migrate this account to PBKDF2:
                        // var envelope = PasswordHasher.Hash(password);
                        // db.SetPasswordEnvelope(username, envelope);

                        db.LoadPlayer(Index, username);
                        serverTCP.SendChars(Index);
                        // SendMaxes(); // if/when used
                        Console.WriteLine(TranslationManager.Instance.GetTranslation("user.logged_in"),
                            username, ServerTCP.Clients[Index].IP);
                    }
                    else
                    {
                        serverTCP.AlertMsg(Index, "incorrect_password");
                    }
                }
                catch (FormatException)
                {
                    // Stored hash not Base64? Treat as invalid.
                    serverTCP.AlertMsg(Index, "incorrect_password");
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

                username = Username.Normalize(username);

                // Check if the username exists in the database
                if (db.AccountExist(username))
                {
                    // Check if the character already exists
                    if (db.CharacterExist(charName))
                    {
                        // If the character name already exists, send an error message
                        serverTCP.AlertMsg(Index, "character_exists");
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
                    serverTCP.AlertMsg(Index, "account_notexist");
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
        private void HandleCommand(int Index, byte[] data)
        {
            using var buffer = new PacketBuffer();
            buffer.AddBytes(data);
            buffer.GetInteger();          // skip packet id
            string text = buffer.GetString();

            World.WorldService.HandleCommand(Index, text);
        }

    }
}