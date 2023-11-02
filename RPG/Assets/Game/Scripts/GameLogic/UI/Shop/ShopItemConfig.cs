using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.GameLogic.UI
{
    [CreateAssetMenu(fileName = "ShopItemConfig", menuName = "Gameplay/Shop/ShopItemConfig", order = 0)]
    public class ShopItemConfig : ScriptableObject
    {
        [SerializeField] private int price;
        [Tooltip("Shop Item Type is used as a Config Key for loading icons")]
        [SerializeField] private string shopItemType;
        private bool _isOwned;

        public void Load()
        {
            _isOwned = PlayerSave.Instance.IsItemBought(name);
        }

        public int Price { get => price; }
        public string ShopItemType { get => shopItemType; }
        public bool IsOwned { get => _isOwned; }
    }
}