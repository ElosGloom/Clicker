using System;
using System.Collections.Generic;

namespace Game.Scripts
{
    public static class Inventory
    {
        public static event Action<string, int> ItemCountChangeEvent;
        public static event Action InventoryUpdateEvent;

        private static readonly Dictionary<string, int> _items = new();


        public static void AddItem(string itemName, int itemCount)
        {
            if (!_items.ContainsKey(itemName))
                _items.Add(itemName, itemCount);
            else
                _items[itemName] += itemCount;

            ItemCountChangeEvent?.Invoke(itemName, _items[itemName]);
            InventoryUpdateEvent?.Invoke();
        }

        public static int GetItemsCount(string itemName)
        {
            if (_items.ContainsKey(itemName))
            {
                return _items[itemName];
            }

            return 0;
        }

        public static int GetAllItemsCount()
        {
            int totalItemsCount = 0;
            foreach (var kvp in _items)
            {
                totalItemsCount += kvp.Value;
            }

            return totalItemsCount;
        }
    }
}