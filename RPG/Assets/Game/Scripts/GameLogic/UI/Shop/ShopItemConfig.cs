using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.GameLogic.UI
{
    [CreateAssetMenu(fileName = "ShopItemConfig", menuName = "Gameplay/Shop/ShopItemConfig", order = 0)]
    public class ShopItemConfig : ScriptableObject
    {
        [SerializeField] private int price;

        public int Price { get => price; }
    }
}