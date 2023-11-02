using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Game.GameLogic.UI
{
    public class PlayerGearExplorer : MonoBehaviour
    {
        public static PlayerGearExplorer Instance;

        [SerializeField] private GameObject items;
        [SerializeField] private PlayerGearExplorerItem prefabForEquipped;
        [SerializeField] private PlayerGearExplorerItem prefabForUnequipped;

        private PlayerGearItemConfig[] _playerGearItemConfigs;
        private PlayerGearSlot[] _playerGearSlot;

        public PlayerGearItemConfig[] PlayerGearItemConfigs { get => _playerGearItemConfigs; }

        private void Awake()
        {
            if (Instance == null)
                Instance = this;
            else
                Destroy(gameObject);

            _playerGearItemConfigs = Resources.LoadAll<PlayerGearItemConfig>("Configs/PlayerGearItems");
            _playerGearSlot = GetComponentsInChildren<PlayerGearSlot>(true);
        }

        private void OnEnable()
        {
            GameManager.Instance.IsInputAllowed = false;
            
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
                if (config.IsOwned() == false) continue;

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
            bool isItemSuccessfullyEquipped = false;
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
                            isItemSuccessfullyEquipped = true;
                            break;
                        }
                    }

                    noneItemSelected = false;
                }
            }

            if (noneItemSelected) return;
            
            if (isItemSuccessfullyEquipped == false)
            {
                GetComponentInChildren<PlayerGearCannotEquipWarning>().Show();
                return;
            }

            DestroyAllItems();
            GenerateEquippedItems();
            GenerateUnequippedItems();
            Player.Instance.OnGearChange?.Invoke();
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
            Player.Instance.OnGearChange?.Invoke();
        }

        public void SellSelectedItemFromGear()
        {
            bool noneItemSelected = true;
            foreach (var item in GetComponentsInChildren<PlayerGearExplorerItem>())
            {
                if (item.IsSelected)
                {
                    item.Sell();
                    noneItemSelected = false;
                    break;
                }
            }

            if (noneItemSelected) return;

            DestroyAllItems();
            GenerateEquippedItems();
            GenerateUnequippedItems();
            Player.Instance.OnGearChange?.Invoke();
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