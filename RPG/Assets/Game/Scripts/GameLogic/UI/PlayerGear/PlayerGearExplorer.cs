using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.GameLogic.UI
{
    public class PlayerGearExplorer : MonoBehaviour
    {
        [SerializeField] private GameObject items;
        [SerializeField] private PlayerGearExplorerItem prefab;

        private PlayerGearItemConfig[] _playerGearItemConfigs;

        private void OnEnable()
        {
            GameManager.Instance.IsInputAllowed = false;

            _playerGearItemConfigs = Resources.LoadAll<PlayerGearItemConfig>("Configs/PlayerGearItems");

            foreach (var config in _playerGearItemConfigs)
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