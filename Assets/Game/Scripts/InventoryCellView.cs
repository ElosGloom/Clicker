using TMPro;
using UnityEngine;

namespace Game.Scripts
{
    /// <summary>
    /// Отображает количество предметов в инвентаре. 
    /// </summary>
    public class InventoryCellView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI itemCounterText;

        public void SetCounterText(int itemsCount)
        {
            itemCounterText.text = itemsCount.ToString();
        }
    }
}