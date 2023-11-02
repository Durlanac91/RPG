using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.GameLogic.UI
{
    [CreateAssetMenu(fileName = "PlayerGearItemConfig", menuName = "Gameplay/PlayerGear/PlayerGearItemConfig", order = 0)]
    public class PlayerGearItemConfig : ScriptableObject
    {
        //[SerializeField] private int price;
        [SerializeField] private string displayName;
        [Tooltip("Gear Item Class is used as a Config Key for loading icons and classification")]
        [SerializeField] private string gearItemClass;
        [Tooltip("Gear Item Type is used as a Config Key for classification")]
        [SerializeField] private string gearItemType;
        private bool _isEquipped;

        public void Load()
        {
            _isEquipped = PlayerSave.Instance.IsItemEquipped(name);
        }

        public bool IsOwned()
        {
            return PlayerSave.Instance.IsItemBought(name);
        }

        //public int Price { get => price; }
        public string GearItemClass { get => gearItemClass; }
        public string GearItemType { get => gearItemType; }
        public bool IsEquipped { get => _isEquipped; }
        public string DisplayName { get => displayName; }
    }
}