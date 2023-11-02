using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.GameLogic.UI
{
    public class PlayerGearExplorer : MonoBehaviour
    {
        [SerializeField] private GameObject items;
        [SerializeField] private PlayerGearExplorerItem prefabForEquipped;
        [SerializeField] private PlayerGearExplorerItem prefabForUnequipped;

        private PlayerGearItemConfig[] _playerGearItemConfigs;
        private PlayerGearSlot[] _playerGearSlot;

        public PlayerGearItemConfig[] PlayerGearItemConfigs { get => _playerGearItemConfigs; }

        private void OnEnable()
        {
            GameManager.Instance.IsInputAllowed = false;
            _playerGearItemConfigs = Resources.LoadAll<PlayerGearItemConfig>("Configs/PlayerGearItems");
            _playerGearSlot = GetComponentsInChildren<PlayerGearSlot>(true);

            foreach (var slot in _playerGearSlot)
            {
                slot.Initialize();
            }

            GenerateEquippedItems();
            GenerateUnequippedItems();
        }

        private void GenerateEquippedItems()
        {
            foreach (var config in _playerGearItemConfigs)
            {
                if (config.IsEquipped)
                {
                    foreach (var slot in _playerGearSlot)
                    {
                        if (slot.IsSlotEmpty()) continue;

                        if (slot.SlotClass == config.GearItemClass
                            && slot.SlotType == config.GearItemType)
                        {
                            var newItem = Instantiate(prefabForEquipped, slot.transform);
                            newItem.Initialize(config);
                            newItem.gameObject.SetActive(true);
                        }
                    }
                }
            }
        }

        private void GenerateUnequippedItems()
        {
            foreach (var config in _playerGearItemConfigs)
            {
                if (config.IsEquipped) continue;
                if (config.IsOwned == false) continue;

                var newItem = Instantiate(prefabForUnequipped, items.transform);
                newItem.Initialize(config);
                newItem.gameObject.SetActive(true);
            }
        }

        public void DeselectAllItems()
        {
            foreach (var item in GetComponentsInChildren<PlayerGearExplorerItem>())
            {
                item.Deselect();
            }
        }

        public void EquipSelectedItemFromGear()
        {
            bool noneItemSelected = true;
            foreach (var item in items.GetComponentsInChildren<PlayerGearExplorerItem>())
            {
                if (item.IsSelected)
                {
                    foreach (var slot in _playerGearSlot)
                    {
                        if (slot.IsSlotEmpty() == false) continue;

                        if (slot.SlotClass == item.PlayerGearItemConfig.GearItemClass
                            && slot.SlotType == item.PlayerGearItemConfig.GearItemType)
                        {
                            item.Equip();
                            noneItemSelected = false;
                            break;
                        }
                    }
                }
            }

            if (noneItemSelected) return;

            DestroyAllItems();
            GenerateEquippedItems();
            GenerateUnequippedItems();
        }

        public void UnequipSelectedItemFromGear()
        {
            bool noneItemSelected = true;
            foreach (var item in GetComponentsInChildren<PlayerGearExplorerItem>())
            {
                if (item.IsSelected && item.PlayerGearItemConfig.IsEquipped)
                {
                    item.Unequip();
                    noneItemSelected = false;
                    break;
                }
            }

            if (noneItemSelected) return;

            DestroyAllItems();
            GenerateEquippedItems();
            GenerateUnequippedItems();

            
        }

        private void DestroyAllItems()
        {
            foreach (var item in GetComponentsInChildren<PlayerGearExplorerItem>())
            {
                Destroy(item.gameObject);
            }
        }

        private void OnDisable()
        {
            DestroyAllItems();
            GameManager.Instance.IsInputAllowed = true;
        }
    }
}