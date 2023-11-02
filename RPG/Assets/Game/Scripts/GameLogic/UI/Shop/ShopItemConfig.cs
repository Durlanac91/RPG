using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.GameLogic.UI
{
    [CreateAssetMenu(fileName = "ShopItemConfig", menuName = "Gameplay/Shop/ShopItemConfig", order = 0)]
    public class ShopItemConfig : ScriptableObject
    {
        [SerializeField] private string displayName;
        [SerializeField] private int price;
        [Tooltip("Shop Item Type is used as a Config Key for loading icons")]
        [SerializeField] private string shopItemType;

        public bool IsOwned()
        {
            return PlayerSave.Instance.IsItemBought(name);
        }

        public int Price { get => price; }
        public string ShopItemType { get => shopItemType; }
        public string DisplayName { get => displayName; }
    }
}