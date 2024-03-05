using UnityEngine;
using UnityEngine.UI;

namespace Game.Scripts
{
    public class AddItemButton : MonoBehaviour
    {
        [SerializeField] private string itemKey;
        [SerializeField, Min(1)] private int itemsCount = 1;
        [SerializeField] private Button button;

        private void Start()
        {
            button.onClick.AddListener(AddItem);
        }

        private void AddItem()
        {
            Inventory.AddItem(itemKey, itemsCount);
        }
    }
}