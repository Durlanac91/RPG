using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Game.GameLogic.UI
{
    [CreateAssetMenu(fileName = "ShopKeeperDescriptionConfigProvider", menuName = "Gameplay/Info/ShopKeeperDescriptionConfigProvider", order = 0)]
    public class ShopKeeperDescriptionConfigProvider : ScriptableObject
    {
        [SerializeField] private List<ShopKeeperDescriptionConfig> infoPopupDescriptionConfig;

        public List<ShopKeeperDescriptionConfig> InfoPopupDescriptionConfig { get => infoPopupDescriptionConfig; }

        public ShopKeeperDescriptionConfig GetConfig(string shopKeeperName)
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