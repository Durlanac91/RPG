using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.GameLogic.UI
{
    public class PlayerGearSlot : MonoBehaviour
    {
        [Tooltip("Slot Class is used for classification")]
        [SerializeField] private string slotClass;
        [Tooltip("Slot Type is used for classification")]
        [SerializeField] private GearItemType slotType;

        private PlayerGearExplorer _playerGearExplorer;

        public void Initialize()
        {
            _playerGearExplorer = GetComponentInParent<PlayerGearExplorer>();
        }

        public string SlotClass { get => slotClass; }
        public GearItemType SlotType { get => slotType; }

        public bool IsSlotEmpty()
        {
            foreach (var config in _playerGearExplorer.PlayerGearItemConfigs)
            {
                if (config.IsEquipped == false) continue;

                if (config.GearItemClass == SlotClass && config.GearItemType == slotType)
                    return false;
            }

            return true;
        }
    }
}