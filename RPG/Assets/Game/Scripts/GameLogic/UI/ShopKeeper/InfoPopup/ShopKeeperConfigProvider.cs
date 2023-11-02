using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Game.GameLogic.UI
{
    [CreateAssetMenu(fileName = "ShopKeeperDescriptionConfigProvider", menuName = "Gameplay/Info/ShopKeeperDescriptionConfigProvider", order = 0)]
    public class ShopKeeperConfigProvider : ScriptableObject
    {
        [SerializeField] private List<ShopKeeperConfig> infoPopupDescriptionConfig;

        public List<ShopKeeperConfig> InfoPopupDescriptionConfig { get => infoPopupDescriptionConfig; }

        public ShopKeeperConfig GetConfig(string shopKeeperName)
        {
            foreach (var config in infoPopupDescriptionConfig)
            {
                if (config.Name == shopKeeperName)
                {
                    return config;
                }
            }

            return infoPopupDescriptionConfig.FirstOrDefault();
        }
    }
}