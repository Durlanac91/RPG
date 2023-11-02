using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.GameLogic.UI
{
    public class PlayerGearExplorerItem : MonoBehaviour
    {
        //[SerializeField] private SpentableResource spentableResource;
        [SerializeField] private Image selectedOverlay;
        [SerializeField] private TextMeshProUGUI textName;
        [SerializeField] private Image mainIcon;

        private PlayerGearExplorer _playerGearExplorer;
        private PlayerGearItemConfig _playerGearItemConfig;
        private bool _isSelected;

        public bool IsSelected { get => _isSelected; }
        public PlayerGearItemConfig PlayerGearItemConfig { get => _playerGearItemConfig; }

        private void Start()
        {
            // neki drugi refresh
        }

        public void Initialize(PlayerGearItemConfig config)
        {
            _playerGearItemConfig = config;
            textName.text = config.DisplayName;
            mainIcon.sprite = Resources.Load<Sprite>("Assets/" + config.GearItemClass + "/" + config.name);

            _playerGearExplorer = GetComponentInParent<PlayerGearExplorer>();
        }

        public void Select()
        {
            _playerGearExplorer.DeselectAllItems();
            _isSelected = true;
            selectedOverlay.gameObject.SetActive(true);
        }

        public void Deselect()
        {
            selectedOverlay.gameObject.SetActive(false);
            _isSelected = false;
        }

        public void Equip()
        {
            PlayerSave.Instance.SetItemEquipped(_playerGearItemConfig.name);
            _playerGearItemConfig.Load();
            _playerGearExplorer.DeselectAllItems();
        }

        public void Unequip()
        {
            PlayerSave.Instance.SetItemUnequipped(_playerGearItemConfig.name);
            _playerGearItemConfig.Load();
            _playerGearExplorer.DeselectAllItems();
        }
    }
}