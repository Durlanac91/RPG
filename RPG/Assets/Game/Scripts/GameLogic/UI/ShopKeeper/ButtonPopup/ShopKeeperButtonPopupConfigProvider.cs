using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.GameLogic.UI
{
    [CreateAssetMenu(fileName = "ShopKeeperButtonPopupConfigProvider", menuName = "Gameplay/Info/ShopKeeperButtonPopupConfigProvider", order = 0)]
    public class ShopKeeperButtonPopupConfigProvider : ScriptableObject
    {
        [SerializeField] private List<ShopKeeperButtonPopupConfig> shopKeeperButtonPopupConfig;

        public List<ShopKeeperButtonPopupConfig> ShopKeeperButtonPopupConfig { get => shopKeeperButtonPopupConfig; }
    }
}