using Bindings;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Collections.Generic;
using System.Net.Sockets;

namespace MirageMUD_Server
{
    internal class SHandleData
    {
        private delegate void Packet_(int  Index, byte[] data);
        private Dictionary<int, Packet_> Packets;
        private Database db = new Database();

        public void InitialiseMessages()
        {
            Console.WriteLine(TranslationManager.Instance.GetTranslation("server.initialising_network_packets"));
            Packets = new Dictionary<int, Packet_>();

            Packets.Add((int)ClientPackets.CGetClasses, HandleGetClasses);
            Packets.Add((int)ClientPackets.CNewAccount, HandleNewAccount);
            Packets.Add((int)ClientPackets.CDelAccount, HandleDelAccount);
            Packets.Add((int)ClientPackets.CLogin, HandleLogin);
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

        }

        public void HandleMessages(int Index, byte[] data)
        {
            if (data == null || data.Length == 0)
            {
                Console.WriteLine(TranslationManager.Instance.GetTranslation("errors.null_or_empty_data"));
                return;
            }

            if (Packets == null)
            {
                Console.WriteLine(TranslationManager.Instance.GetTranslation("errors.uninitialized_packets"));
                return;
            }

            int packetNum;
            using (PacketBuffer buffer = new PacketBuffer())
            {
                buffer.AddBytes(data);
                packetNum = buffer.GetInteger();
            }

            if (Packets.TryGetValue(packetNum, out Packet_ packet))
            {
                packet.Invoke(Index, data);
            }
            else
            {
                Console.WriteLine(string.Format(
                    TranslationManager.Instance.GetTranslation("errors.no_handler"), packetNum));
            }
        }

        private void HandleGetClasses(int Index, byte[] data) { }
        private void HandleNewAccount(int Index, byte[] data)
        {
            using (PacketBuffer buffer = new PacketBuffer())
            {
                buffer.AddBytes(data);
                buffer.GetInteger(); // Skip packet ID
                string username = buffer.GetString();
                string password = buffer.GetString();

                // Generate a random salt (16 bytes)
                byte[] salt = new byte[16];
                using (var rng = new RNGCryptoServiceProvider())
                {
                    rng.GetBytes(salt);
                }

                // Combine password and salt
                string passwordWithSalt = password + Convert.ToBase64String(salt);

                // Hash the password + salt using SHA256
                using (SHA256 sha256 = SHA256.Create())
                {
                    byte[] hashedPassword = sha256.ComputeHash(Encoding.UTF8.GetBytes(passwordWithSalt));

                    // Check if the account already exists
                    if (!db.AccountExist(username))
                    {
                        // Store the hashed password and salt
                        db.AddAccount(Index, username, Convert.ToBase64String(hashedPassword), Convert.ToBase64String(salt));
                        Console.WriteLine(TranslationManager.Instance.GetTranslation("user.account_created"));
                    }
                    else
                    {
                        Console.WriteLine(TranslationManager.Instance.GetTranslation("user.username_exists"));
                        // Optionally send an alert back to the client
                        // AlertMsg("Username already exists.");
                    }
                }
            }
        }
        private void HandleDelAccount(int Index, byte[] data) { }
        private void HandleLogin(int Index, byte[] data)
        {
            using (PacketBuffer buffer = new PacketBuffer())
            {
                buffer.AddBytes(data);
                buffer.GetInteger(); // Skip packet ID
                string username = buffer.GetString();
                string password = buffer.GetString();
                byte major = buffer.GetByte();
                byte minor = buffer.GetByte();
                byte rev = buffer.GetByte();

                if (!db.AccountExist(username))
                {
                    Console.WriteLine(string.Format(
                        TranslationManager.Instance.GetTranslation("errors.file_not_found"), username));
                    return;
                }

                // Retrieve the stored hashed password and salt for the user
                string storedHashedPassword = db.GetHashedPassword(username); // Base64 string
                string storedSalt = db.GetSalt(username); // Base64 string

                if (storedHashedPassword == null || storedSalt == null)
                {
                    Console.WriteLine(string.Format(
                        TranslationManager.Instance.GetTranslation("errors.account_corrupted"), username));
                    return;
                }

                // Convert the stored salt from Base64 to byte array
                byte[] salt = Convert.FromBase64String(storedSalt);

                // Combine the entered password with the stored salt
                string passwordWithSalt = password + Convert.ToBase64String(salt);

                // Hash the combined entered password and salt using SHA256
                using (SHA256 sha256 = SHA256.Create())
                {
                    byte[] hashedEnteredPassword = sha256.ComputeHash(Encoding.UTF8.GetBytes(passwordWithSalt));

                    // Convert the hashed entered password to Base64
                    string hashedEnteredPasswordBase64 = Convert.ToBase64String(hashedEnteredPassword);

                    // Compare the hashed entered password with the stored hashed password
                    if (hashedEnteredPasswordBase64 != storedHashedPassword)
                    {
                        Console.WriteLine(string.Format(
                            TranslationManager.Instance.GetTranslation("errors.password_mismatch"), username));
                        return;
                    }
                }

                Console.WriteLine(string.Format(
                    TranslationManager.Instance.GetTranslation("user.logged_in"),
                    username,
                    ServerTCP.Clients[Index].IP));

                db.LoadPlayer(Index, username);
                // Additional logic (e.g., SendChars, SendMaxes, SendRoomRevs)
            }
        }
        private void HandleAddChar(int Index, byte[] data) { }
        private void HandleDelChar(int Index, byte[] data) { }
        private void HandleUseChar(int Index, byte[] data) { }
        private void HandleSayMsg(int Index, byte[] data) { }
        private void HandleEmoteMsg(int Index, byte[] data) { }
        private void HandleBroadcastMsg(int Index, byte[] data) { }
        private void HandleGlobalMsg(int Index, byte[] data) { }
        private void HandleAdminMsg(int Index, byte[] data) { }
        private void HandlePlayerMsg(int Index, byte[] data) { }
        private void HandlePlayerMove(int Index, byte[] data) { }
        private void HandlePlayerDir(int Index, byte[] data) { }
        private void HandleUseItem(int Index, byte[] data) { }
        private void HandleAttack(int Index, byte[] data) { }
        private void HandleUseStatPoint(int Index, byte[] data) { }
        private void HandlePlayerInfoRequest(int Index, byte[] data) { }
        private void HandleWarpMeTo(int Index, byte[] data) { }
        private void HandleWarpToMe(int Index, byte[] data) { }
        private void HandleWarpTo(int Index, byte[] data) { }
        private void HandleSetAvatar(int Index, byte[] data) { }
        private void HandleGetStats(int Index, byte[] data) { }
        private void HandleRequestNewRoom(int Index, byte[] data) { }
        private void HandleRoomData(int Index, byte[] data) { }
        private void HandleNeedRoom(int Index, byte[] data) { }
        private void HandleRoomGetItem(int Index, byte[] data) { }
        private void HandleRoomDropItem(int Index, byte[] data) { }
        private void HandleRoomRespawn(int Index, byte[] data) { }
        private void HandleRoomReport(int Index, byte[] data) { }
        private void HandleKickPlayer(int Index, byte[] data) { }
        private void HandleBanList(int Index, byte[] data) { }
        private void HandleBanDestroy(int Index, byte[] data) { }
        private void HandleBanPlayer(int Index, byte[] data) { }
        private void HandleRequestEditRoom(int Index, byte[] data) { }
        private void HandleRequestEditItem(int Index, byte[] data) { }
        private void HandleEditItem(int Index, byte[] data) { }
        private void HandleSaveItem(int Index, byte[] data) { }
        private void HandleRequestEditNpc(int Index, byte[] data) { }
        private void HandleEditNpc(int Index, byte[] data) { }
        private void HandleSaveNpc(int Index, byte[] data) { }
        private void HandleRequestEditShop(int Index, byte[] data) { }
        private void HandleEditShop(int Index, byte[] data) { }
        private void HandleSaveShop(int Index, byte[] data) { }
        private void HandleRequestEditSpell(int Index, byte[] data) { }
        private void HandleEditSpell(int Index, byte[] data) { }
        private void HandleSaveSpell(int Index, byte[] data) { }
        private void HandleDelete(int Index, byte[] data) { }
        private void HandleSetAccess(int Index, byte[] data) { }
        private void HandleWhosOnline(int Index, byte[] data) { }
        private void HandleSetMotd(int Index, byte[] data) { }
        private void HandleTrade(int Index, byte[] data) { }
        private void HandleTradeRequest(int Index, byte[] data) { }
        private void HandleFixItem(int Index, byte[] data) { }
        private void HandleSearch(int Index, byte[] data) { }
        private void HandleParty(int Index, byte[] data) { }
        private void HandleJoinParty(int Index, byte[] data) { }
        private void HandleLeaveParty(int Index, byte[] data) { }
        private void HandleSpells(int Index, byte[] data) { }
        private void HandleCast(int Index, byte[] data) { }
        private void HandleQuit(int Index, byte[] data) { }
        private void HandleSync(int Index, byte[] data) { }
        private void HandleRoomReqs(int Index, byte[] data) { }
        private void HandleSleepInn(int Index, byte[] data) { }
        private void HandleRemoveFromGuild(int Index, byte[] data) { }
        private void HandleCreateGuild(int Index, byte[] data) { }
        private void HandleInviteGuild(int Index, byte[] data) { }
        private void HandleKickGuild(int Index, byte[] data) { }
        private void HandleGuildPromote(int Index, byte[] data) { }
        private void HandleLeaveGuild(int Index, byte[] data) { }

    }
}
