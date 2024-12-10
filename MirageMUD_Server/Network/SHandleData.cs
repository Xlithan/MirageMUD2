using Bindings;
using System.Security.Cryptography;
using System.Text;
using MirageMUD_Server.Storage;

namespace MirageMUD_Server.Network
{
    internal class SHandleData
    {
        private delegate Task Packet_(int Index, byte[] data);
        private Dictionary<int, Packet_> Packets;
        private Database db = new Database();
        private ServerWebSocket serverWebSocket = new ServerWebSocket();

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

            int packetNum = data[0];

            if (Packets.TryGetValue(packetNum, out Packet_ packet))
            {
                packet.Invoke(Index, data);
            }
            else
            {
                Console.WriteLine($"No handler for packet {packetNum}");
            }
        }

        private async Task HandleGetClasses(int Index, byte[] data) { }
        private async Task HandleNewAccount(int Index, byte[] data)
        {
            int offset = 1;
            string username = Encoding.UTF8.GetString(data, offset, data.Length - offset - 32);
            offset += username.Length + 1;

            string password = Encoding.UTF8.GetString(data, offset, data.Length - offset);

            // Use `RandomNumberGenerator` instead of deprecated RNGCryptoServiceProvider
            byte[] salt = new byte[16];
            RandomNumberGenerator.Fill(salt);

            string hashedPassword = Convert.ToBase64String(Encoding.UTF8.GetBytes(password + Convert.ToBase64String(salt)));

            if (!db.AccountExist(username))
            {
                db.AddAccount(Index, username, hashedPassword, Convert.ToBase64String(salt));
                Console.WriteLine(TranslationManager.Instance.GetTranslation("user.account_created"));
            }
            else
            {
                serverWebSocket.AlertMsg(Index, "Username already exists.");
            }
        }
        private async Task HandleDelAccount(int Index, byte[] data) { }
        private async Task HandleLogin(int Index, byte[] data)
        {
            int offset = 1;
            string username = Encoding.UTF8.GetString(data, offset, data.Length - offset - 32);
            offset += username.Length;

            string password = Encoding.UTF8.GetString(data, offset, data.Length - offset);

            if (db.AccountExist(username))
            {
                string dbPassword = db.GetHashedPassword(username);
                string dbSalt = db.GetSalt(username);

                string inputHash = Convert.ToBase64String(Encoding.UTF8.GetBytes(password + dbSalt));

                if (inputHash == dbPassword)
                {
                    db.LoadPlayer(Index, username);
                    Console.WriteLine($"User {username} successfully logged in.");
                }
                else
                {
                    await serverWebSocket.AlertMsg(Index, "Incorrect password.");
                }
            }
            else
            {
                await serverWebSocket.AlertMsg(Index, "Account not found.");
            }
        }
        private async Task HandleAddChar(int Index, byte[] data) { }
        private async Task HandleDelChar(int Index, byte[] data) { }
        private async Task HandleUseChar(int Index, byte[] data) { }
        private async Task HandleSayMsg(int Index, byte[] data) { }
        private async Task HandleEmoteMsg(int Index, byte[] data) { }
        private async Task HandleBroadcastMsg(int Index, byte[] data) { }
        private async Task HandleGlobalMsg(int Index, byte[] data) { }
        private async Task HandleAdminMsg(int Index, byte[] data) { }
        private async Task HandlePlayerMsg(int Index, byte[] data) { }
        private async Task HandlePlayerMove(int Index, byte[] data) { }
        private async Task HandlePlayerDir(int Index, byte[] data) { }
        private async Task HandleUseItem(int Index, byte[] data) { }
        private async Task HandleAttack(int Index, byte[] data) { }
        private async Task HandleUseStatPoint(int Index, byte[] data) { }
        private async Task HandlePlayerInfoRequest(int Index, byte[] data) { }
        private async Task HandleWarpMeTo(int Index, byte[] data) { }
        private async Task HandleWarpToMe(int Index, byte[] data) { }
        private async Task HandleWarpTo(int Index, byte[] data) { }
        private async Task HandleSetAvatar(int Index, byte[] data) { }
        private async Task HandleGetStats(int Index, byte[] data) { }
        private async Task HandleRequestNewRoom(int Index, byte[] data) { }
        private async Task HandleRoomData(int Index, byte[] data) { }
        private async Task HandleNeedRoom(int Index, byte[] data) { }
        private async Task HandleRoomGetItem(int Index, byte[] data) { }
        private async Task HandleRoomDropItem(int Index, byte[] data) { }
        private async Task HandleRoomRespawn(int Index, byte[] data) { }
        private async Task HandleRoomReport(int Index, byte[] data) { }
        private async Task HandleKickPlayer(int Index, byte[] data) { }
        private async Task HandleBanList(int Index, byte[] data) { }
        private async Task HandleBanDestroy(int Index, byte[] data) { }
        private async Task HandleBanPlayer(int Index, byte[] data) { }
        private async Task HandleRequestEditRoom(int Index, byte[] data) { }
        private async Task HandleRequestEditItem(int Index, byte[] data) { }
        private async Task HandleEditItem(int Index, byte[] data) { }
        private async Task HandleSaveItem(int Index, byte[] data) { }
        private async Task HandleRequestEditNpc(int Index, byte[] data) { }
        private async Task HandleEditNpc(int Index, byte[] data) { }
        private async Task HandleSaveNpc(int Index, byte[] data) { }
        private async Task HandleRequestEditShop(int Index, byte[] data) { }
        private async Task HandleEditShop(int Index, byte[] data) { }
        private async Task HandleSaveShop(int Index, byte[] data) { }
        private async Task HandleRequestEditSpell(int Index, byte[] data) { }
        private async Task HandleEditSpell(int Index, byte[] data) { }
        private async Task HandleSaveSpell(int Index, byte[] data) { }
        private async Task HandleDelete(int Index, byte[] data) { }
        private async Task HandleSetAccess(int Index, byte[] data) { }
        private async Task HandleWhosOnline(int Index, byte[] data) { }
        private async Task HandleSetMotd(int Index, byte[] data) { }
        private async Task HandleTrade(int Index, byte[] data) { }
        private async Task HandleTradeRequest(int Index, byte[] data) { }
        private async Task HandleFixItem(int Index, byte[] data) { }
        private async Task HandleSearch(int Index, byte[] data) { }
        private async Task HandleParty(int Index, byte[] data) { }
        private async Task HandleJoinParty(int Index, byte[] data) { }
        private async Task HandleLeaveParty(int Index, byte[] data) { }
        private async Task HandleSpells(int Index, byte[] data) { }
        private async Task HandleCast(int Index, byte[] data) { }
        private async Task HandleQuit(int Index, byte[] data) { }
        private async Task HandleSync(int Index, byte[] data) { }
        private async Task HandleRoomReqs(int Index, byte[] data) { }
        private async Task HandleSleepInn(int Index, byte[] data) { }
        private async Task HandleRemoveFromGuild(int Index, byte[] data) { }
        private async Task HandleCreateGuild(int Index, byte[] data) { }
        private async Task HandleInviteGuild(int Index, byte[] data) { }
        private async Task HandleKickGuild(int Index, byte[] data) { }
        private async Task HandleGuildPromote(int Index, byte[] data) { }
        private async Task HandleLeaveGuild(int Index, byte[] data) { }
    }
}
