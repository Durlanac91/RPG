using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.GameLogic.UI
{
    [CreateAssetMenu(fileName = "ShopKeeperConfig", menuName = "Gameplay/Info/ShopKeeperConfig", order = 0)]
    public class ShopKeeperConfig : ScriptableObject
    {
        [Tooltip("Name is used as a Key")]
        [SerializeField] private string name;
        [SerializeField] private string shopItemsPath;
        [SerializeField, TextArea(15, 15)] private string description;

        public string Name { get => name; }
        public string ShopItemsPath { get => shopItemsPath; }
        public string Description { get => description; }
    }
}