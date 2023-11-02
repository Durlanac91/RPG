using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.GameLogic.UI
{
    [CreateAssetMenu(fileName = "ShopKeeperDescriptionConfig", menuName = "Gameplay/Info/ShopKeeperDescriptionConfig", order = 0)]
    public class ShopKeeperDescriptionConfig : ScriptableObject
    {
        public string Name;
        [SerializeField, TextArea(15, 15)] public string Description;
    }
}