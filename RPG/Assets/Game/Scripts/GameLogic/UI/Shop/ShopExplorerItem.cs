using Game.GameLogic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Game.GameLogic.UI
{
    public class ShopExplorerItem : MonoBehaviour
    {
        [SerializeField] private SpentableResource spentableResource;
        [SerializeField] private Image notEnoughCoinsOverlay;
        [SerializeField] private Image selectedOverlay;
        [SerializeField] private Image alreadyBoughtOverlay;

        private int _price;

        private void Start()
        {
            spentableResource.OnChange.AddListener(Refresh);
        }

        public void Initialize(ShopItemConfig config)
        {
            _price = config.Price;
        }

        public void Refresh()
        {

        }

        private void OnDestroy()
        {
            spentableResource.OnChange.RemoveListener(Refresh);
        }
    }
}