using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.GameLogic.UI
{
    public class ShopExplorer : MonoBehaviour
    {
        [SerializeField] private GameObject items;
        [SerializeField] private ShopExplorerItem prefab;

        private ShopItemConfig[] _shopItemConfigs;
        private string _shopItemsPath;

        public string ShopItemsPath { get => _shopItemsPath; set => _shopItemsPath = value; }

        private void OnEnable()
        {
            _shopItemConfigs = Resources.LoadAll<ShopItemConfig>(_shopItemsPath);
            GameManager.Instance.IsInputAllowed = false;

            foreach (var config in _shopItemConfigs)
            {
                var newItem = Instantiate(prefab, items.transform);
                newItem.Initialize(config);
                newItem.gameObject.SetActive(true);
            }
        }

        public void DeselectAllItems()
        {
            foreach (var item in items.GetComponentsInChildren<ShopExplorerItem>())
            {
                item.Deselect();
            }
        }

        public void BuySelectedItemFromShop()
        {
            foreach (var item in items.GetComponentsInChildren<ShopExplorerItem>())
            {
                if (item.IsSelected)
                {
                    item.Buy();
                    break;
                }
            }
        }

        private void OnDisable()
        {
            foreach (var item in items.GetComponentsInChildren<ShopExplorerItem>())
            {
                Destroy(item.gameObject);
            }

            GameManager.Instance.IsInputAllowed = true;
        }
    }
}