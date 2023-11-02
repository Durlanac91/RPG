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

        // Skins
        public void SetSkinUnlocked(string skinName)
        {
            PlayerPrefs.SetInt("skins_" + skinName, 1);
        }

        public bool GetIsSkinLocked(string skinName)
        {
            return PlayerPrefs.GetInt("skins_" + skinName, 0) == 0;
        }

        public int GetSkinsUnlocked()
        {
            return PlayerPrefs.GetInt("skinsUnlocked", 0);
        }

        public void SetSkinsUnlocked(int skinsUnlocked)
        {
            PlayerPrefs.SetInt("skinsUnlocked", skinsUnlocked);
        }

        public void UnlockNextSkin()
        {
            var current = GetSkinsUnlocked();
            SetSkinsUnlocked(current + 1);
        }

        public void SetEquippedSkin(string skinName)
        {
            PlayerPrefs.SetString("skins_equipped", skinName);
        }

        public string GetEquippedSkin()
        {
            return PlayerPrefs.GetString("skins_equipped", "skin_001");
        }
        // - - - -

        // Onboarding

        public void SetLevelOnboaringFinished()
        {
            PlayerPrefs.SetInt("onboarding_level_finished", 1);
        }

        public bool GetIsLevelOnboaringFinished()
        {
            return PlayerPrefs.GetInt("onboarding_level_finished", 0) == 0;
        }

        public void SetBoosterOnboaringShown()
        {
            PlayerPrefs.SetInt("onboarding_booster_shown", 1);
        }

        public bool GetIsBoosterOnboaringShown()
        {
            return PlayerPrefs.GetInt("onboarding_booster_shown", 0) == 0;
        }

        public void SetSkinDeepLink(bool status)
        {
            PlayerPrefs.SetInt("skin_deepLink", Convert.ToInt32(status));
        }

        public bool IsSkinDeepLinkActive()
        {
            return Convert.ToBoolean(PlayerPrefs.GetInt("skin_deepLink", 0));
        }
        // - - - -

        public void DeleteAllData()
        {
            PlayerPrefs.DeleteAll();
        }
    }
}
