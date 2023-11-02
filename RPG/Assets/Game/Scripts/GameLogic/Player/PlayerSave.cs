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

        public void ItemBought(string itemName)
        {
            PlayerPrefs.SetInt("item_bought_" + itemName, 1);
        }

        public void ItemSell(string itemName)
        {
            PlayerPrefs.SetInt("item_bought_" + itemName, 0);
        }

        public void SetItemEquipped(string itemName)
        {
            PlayerPrefs.SetInt("item_equipped_" + itemName, 1);
        }

        public void SetItemUnequipped(string itemName)
        {
            PlayerPrefs.SetInt("item_equipped_" + itemName, 0);
        }

        public bool IsItemEquipped(string itemName)
        {
            return Convert.ToBoolean(PlayerPrefs.GetInt("item_equipped_" + itemName, 0));
        }

        // - - - -

        public void DeleteAllData()
        {
            PlayerPrefs.DeleteAll();
        }
    }
}
