using System;
using UnityEngine;

namespace Game.GameLogic
{
    public class PlayerSave : MonoBehaviour
    {
        public static PlayerSave Instance;
        
        private void Awake()
        {
            if (Instance == null)
                Instance = this;
            else
                Destroy(this);
        }

        //Resources

        public int GetResource(string saveKey)
        {
            return PlayerPrefs.GetInt(saveKey + "_resource", 0);
        }
        
        public void SetResource(string saveKey, int amount)
        {
            PlayerPrefs.SetInt(saveKey + "_resource", amount);
        }

        // - - - -

        // ShopItems

        public bool IsItemBought(string itemName)
        {
            return Convert.ToBoolean(PlayerPrefs.GetInt("item_bought_" + itemName, 0));
        }

        public void SetItemBought(string itemName)
        {
            PlayerPrefs.SetInt("item_bought_" + itemName, 1);
        }

        public void IsItemEquipped(string itemName)
        {
            PlayerPrefs.SetString("item_equipped", itemName);
        }

        //public string GetEquippedSkin()
        //{
        //    return PlayerPrefs.GetString("skins_equipped", "skin_001");
        //}

        // - - - -

        public void DeleteAllData()
        {
            PlayerPrefs.DeleteAll();
        }
    }
}
