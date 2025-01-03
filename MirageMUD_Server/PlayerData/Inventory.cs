namespace MirageMUD_Server.PlayerData
{
    // Represents an item in the player's inventory
    internal class Inventory
    {
        // The ID of the item (could refer to a database or item table)
        public int ItemID { get; set; }

        // The quantity of the item the player has
        public int Quantity { get; set; }

        // Constructor to initialize Inventory object with item ID and quantity
        public Inventory(int itemId, int quantity)
        {
            ItemID = itemId; // Set the item ID
            Quantity = quantity; // Set the quantity of the item
        }
    }
}