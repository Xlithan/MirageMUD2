using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MirageMUD_Server.PlayerData
{
    [Serializable]
    internal class Inventory
    {
        public int ItemID { get; set; }
        public int Quantity { get; set; }

        // Constructor
        public Inventory(int itemId, int quantity)
        {
            ItemID = itemId;
            Quantity = quantity;
        }
    }
}
