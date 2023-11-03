using Game.GameLogic.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.GameLogic
{
    public class PlayerBodyPartsEquipController : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer hood;
        [SerializeField] private SpriteRenderer pelvis;
        [SerializeField] private SpriteRenderer torso;
        [SerializeField] private SpriteRenderer weaponLeft;
        [SerializeField] private SpriteRenderer weaponRight;

        private Sprite defaultHood;
        private Sprite defaultPelvis;
        private Sprite defaultTorso;
        private Sprite defaultWeaponLeft;

        private PlayerGearItemConfig[] _playerGearItemConfigs;

        private void Awake()
        {
            defaultHood = hood.sprite;
            defaultPelvis = pelvis.sprite;
            defaultTorso = torso.sprite;
            defaultWeaponLeft = weaponLeft.sprite;

            _playerGearItemConfigs = Resources.LoadAll<PlayerGearItemConfig>("Configs/PlayerGearItems");
            Refresh();
        }

        private void Start()
        {
            Player.Instance.OnGearChange.AddListener(Refresh);
        }

        public void Refresh()
        {
            hood.sprite = defaultHood;
            pelvis.sprite = defaultPelvis;
            torso.sprite = defaultTorso;
            weaponLeft.sprite = defaultWeaponLeft;
            weaponRight.sprite = defaultWeaponLeft;

            foreach (var config in _playerGearItemConfigs)
            {
                if (config.IsEquipped == false) continue;

                if (config.GearItemType == GearItemType.Hood)
                    hood.sprite = Resources.Load<Sprite>("Assets/" + config.GearItemClass + "/" + config.name);
                else if (config.GearItemType == GearItemType.Pelvis)
                    pelvis.sprite = Resources.Load<Sprite>("Assets/" + config.GearItemClass + "/" + config.name);
                else if (config.GearItemType == GearItemType.Torso)
                    torso.sprite = Resources.Load<Sprite>("Assets/" + config.GearItemClass + "/" + config.name);
                else if (config.GearItemType == GearItemType.Weapon)
                {
                    weaponLeft.sprite = Resources.Load<Sprite>("Assets/" + config.GearItemClass + "/" + config.name);
                    weaponRight.sprite = Resources.Load<Sprite>("Assets/" + config.GearItemClass + "/" + config.name);
                }
            }
        }

        private void OnDestroy()
        {
            Player.Instance.OnGearChange.RemoveListener(Refresh);
        }
    }
}