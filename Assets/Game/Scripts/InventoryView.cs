using UnityEngine;

namespace Game.Scripts
{
    public class InventoryView : MonoBehaviour
    {
        [SerializeField] private SerializableDictionary<string, InventoryCellView> cellViews;
        [SerializeField] private InventoryCellView totalItemsCountCell;


        private void Start()
        {
            foreach (var kvp in cellViews)
            {
                int itemCount = Inventory.GetItemsCount(kvp.Key);
                UpdateCell(kvp.Key, itemCount);
            }

            Inventory.ItemCountChangeEvent += UpdateCell;
            Inventory.InventoryUpdateEvent += UpdateTotalItemsCell;
        }

        private void UpdateCell(string itemName, int itemCount)
        {
            if (cellViews.ContainsKey(itemName))
            {
                cellViews[itemName].SetCounterText(itemCount);
            }
        }

        private void UpdateTotalItemsCell()
        {
            totalItemsCountCell.SetCounterText(Inventory.GetAllItemsCount());
        }


        private void OnDestroy()
        {
            Inventory.ItemCountChangeEvent -= UpdateCell;
            Inventory.InventoryUpdateEvent -= UpdateTotalItemsCell;
        }
    }
}