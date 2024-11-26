using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Bindings;

namespace MirageMUD_Client.Source.Network
{
    internal class HandleData
    {
        public PacketBuffer buffer = new PacketBuffer();
        private delegate void Packet_(byte[] data);
        private Dictionary<int, Packet_>? Packets = new Dictionary<int, Packet_>();

        public void InitialiseMessages()
        {
            Packets.Add((int)ServerPackets.SAlertMsg, HandleAlertMsg);
            Packets.Add((int)ServerPackets.SAllChars, HandleAllChars);
            Packets.Add((int)ServerPackets.SLoginOk, HandleLoginOk);
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
        }

        public void HandleMessages(byte[] data)
        {
            if (data == null || data.Length == 0)
                throw new ArgumentException("Data cannot be null or empty.", nameof(data));

            int packetNum;
            using (PacketBuffer buffer = new PacketBuffer())
            {
                buffer.AddBytes(data);
                packetNum = buffer.GetInteger();
            }

            if (Packets == null)
                throw new InvalidOperationException("Packets dictionary is not initialized.");

            if (Packets.TryGetValue(packetNum, out Packet_ packet))
            {
                packet.Invoke(data);
            }
            else
            {
                Console.WriteLine($"No packet handler found for packet number: {packetNum}");
            }
        }


        public void HandleAlertMsg(byte[] data)
        {
        }

        public void HandleAllChars(byte[] data)
        {
        }

        public void HandleLoginOk(byte[] data)
        {
        }

        public void HandleNewCharClasses(byte[] data)
        {
        }

        public void HandleClassesData(byte[] data)
        {
        }

        public void HandleInGame(byte[] data)
        {
        }

        public void HandlePlayerInv(byte[] data)
        {
        }

        public void HandlePlayerInvUpdate(byte[] data)
        {
        }

        public void HandlePlayerWornEq(byte[] data)
        {
        }

        public void HandlePlayerHp(byte[] data)
        {
        }

        public void HandlePlayerMp(byte[] data)
        {
        }

        public void HandlePlayerSp(byte[] data)
        {
        }

        public void HandlePlayerStamina(byte[] data)
        {
        }

        public void HandlePlayerStats(byte[] data)
        {
        }

        public void HandlePlayerData(byte[] data)
        {
        }

        public void HandlePlayerExp(byte[] data)
        {
        }

        public void HandleAttack(byte[] data)
        {
        }

        public void HandleNpcAttack(byte[] data)
        {
        }

        public void HandleCheckForRoom(byte[] data)
        {
        }

        public void HandleRoomData(byte[] data)
        {
        }

        public void HandleRoomItemData(byte[] data)
        {
        }

        public void HandleRoomNpcData(byte[] data)
        {
        }

        public void HandleRoomDone(byte[] data)
        {
        }

        public void HandleSayMsg(byte[] data)
        {
        }

        public void HandleGlobalMsg(byte[] data)
        {
        }

        public void HandleAdminMsg(byte[] data)
        {
        }

        public void HandlePlayerMsg(byte[] data)
        {
        }

        public void HandleRoomMsg(byte[] data)
        {
        }

        public void HandleSpawnItem(byte[] data)
        {
        }

        public void HandleItemEditor(byte[] data)
        {
        }

        public void HandleUpdateItem(byte[] data)
        {
        }

        public void HandleEditItem(byte[] data)
        {
        }

        public void HandleSpawnNpc(byte[] data)
        {
        }

        public void HandleNpcDead(byte[] data)
        {
        }

        public void HandleNpcEditor(byte[] data)
        {
        }

        public void HandleUpdateNpc(byte[] data)
        {
        }

        public void HandleEditNpc(byte[] data)
        {
        }

        public void HandleEditRoom(byte[] data)
        {
        }

        public void HandleShopEditor(byte[] data)
        {
        }

        public void HandleUpdateShop(byte[] data)
        {
        }

        public void HandleEditShop(byte[] data)
        {
        }

        public void HandleRefresh(byte[] data)
        {
        }

        public void HandleSpellEditor(byte[] data)
        {
        }

        public void HandleUpdateSpell(byte[] data)
        {
        }

        public void HandleEditSpell(byte[] data)
        {
        }

        public void HandleTrade(byte[] data)
        {
        }

        public void HandleSpells(byte[] data)
        {
        }

        public void HandleLeft(byte[] data)
        {
        }

        public void HandleHighIndex(byte[] data)
        {
        }

        public void HandleSpellCast(byte[] data)
        {
        }

        public void HandleMaxes(byte[] data)
        {
        }

        public void HandleSync(byte[] data)
        {
        }

        public void HandleRoomRevs(byte[] data)
        {
        }

    }
}