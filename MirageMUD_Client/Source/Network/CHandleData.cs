﻿using Bindings;
using System.Diagnostics;

namespace MirageMUD_WFClient.Source.Network
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
                Debug.WriteLine(string.Format(TranslationManager.Instance.GetTranslation("errors.no_handler"), packetNum));
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
                MessageBox.Show(msg, "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        public void HandleAllChars(byte[] data)
        {
            using(PacketBuffer buffer = new PacketBuffer())
            {
                buffer.AddBytes(data);
                buffer.GetInteger(); // Skip packet ID
                frmMenu.Default.RunOnUIThread(() =>
                    frmMenu.Default.lblAccountName.Text = buffer.GetString());
                string charName;
                for(int i = 0; i < Constants.MAX_CHARS; i++)
                {
                    charName = buffer.GetString();
                    if(charName.Length == 0)
                    {
                        frmMenu.Default.RunOnUIThread(() =>
                            frmMenu.Default.lstCharacters.Items.Add("Empty Slot"));
                    }
                    else
                    {
                        frmMenu.Default.RunOnUIThread(() =>
                            frmMenu.Default.lstCharacters.Items.Add(charName));
                    }

                    frmMenu.Default.RunOnUIThread(() => frmMenu.Default.HidePanels());
                    frmMenu.Default.RunOnUIThread(() => frmMenu.Default.pnlCharacters.Visible = true);

                    // Disable main menu now that we've logged in
                    frmMenu.Default.RunOnUIThread(() => frmMenu.Default.ToggleNav());
                }
            }
        }
        public void HandleLoginOk(byte[] data) { }
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

                frmMenu.Default.RunOnUIThread(() => // Strength
                    frmMenu.Default.lblstat_Str.Text = buffer.GetInteger().ToString());
                frmMenu.Default.RunOnUIThread(() => // Intelligence
                    frmMenu.Default.lblstat_Int.Text = buffer.GetInteger().ToString());
                frmMenu.Default.RunOnUIThread(() => // Dexterity
                    frmMenu.Default.lblstat_Dex.Text = buffer.GetInteger().ToString());
                frmMenu.Default.RunOnUIThread(() => // Constitution
                    frmMenu.Default.lblstat_Con.Text = buffer.GetInteger().ToString());
                frmMenu.Default.RunOnUIThread(() => // Wisdom
                    frmMenu.Default.lblstat_Wis.Text = buffer.GetInteger().ToString());
                frmMenu.Default.RunOnUIThread(() => // Charisma
                    frmMenu.Default.lblstat_Cha.Text = buffer.GetInteger().ToString());
            }
        }
    }
}