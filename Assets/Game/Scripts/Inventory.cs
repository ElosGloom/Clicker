using System;
using System.Collections.Generic;

namespace Game.Scripts
{
    /// <summary>
    /// Хранилище предметов по ключу.
    /// </summary>
    public static class Inventory
    {
        public static event Action<string, int> ItemCountChangeEvent;
        public static event Action InventoryUpdateEvent;

        private static readonly Dictionary<string, int> Items = new();


        public static void AddItem(string itemName, int itemCount)
        {
            if (!Items.ContainsKey(itemName))
                Items.Add(itemName, itemCount);
            else
                Items[itemName] += itemCount;

            ItemCountChangeEvent?.Invoke(itemName, Items[itemName]);
            InventoryUpdateEvent?.Invoke();
        }

        public static int GetItemsCount(string itemName)
        {
            if (Items.ContainsKey(itemName))
            {
                return Items[itemName];
            }

            return 0;
        }

        public static int GetAllItemsCount()
        {
            int totalItemsCount = 0;
            foreach (var kvp in Items)
            {
                totalItemsCount += kvp.Value;
            }

            return totalItemsCount;
        }
    }
}