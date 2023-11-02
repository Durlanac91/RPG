using Game.GameLogic;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.GameLogic.UI
{
    public class ShopExplorerItem : MonoBehaviour
    {
        [SerializeField] private SpentableResource spentableResource;
        [SerializeField] private Image notEnoughCoinsOverlay;
        [SerializeField] private Image selectedOverlay;
        [SerializeField] private Image alreadyBoughtOverlay;
        [SerializeField] private TextMeshProUGUI textPrice;
        [SerializeField] private TextMeshProUGUI textName;
        [SerializeField] private Image mainIcon;

        private int _price;
        private Button _button;
        private ShopExplorer _shopExplorer;
        private ShopItemConfig _shopItemConfig;
        private bool _isSelected;

        public bool IsSelected { get => _isSelected; }

        private void Start()
        {
            spentableResource.OnChange.AddListener(Refresh);
        }

        public void Initialize(ShopItemConfig config)
        {
            _shopItemConfig = config;
            _price = config.Price;
            textPrice.text = _price.ToString();
            textName.text = config.DisplayName;
            mainIcon.sprite = Resources.Load<Sprite>("Assets/" + config.ShopItemType + "/" + config.name);
            _button = GetComponent<Button>();
            _shopExplorer = GetComponentInParent<ShopExplorer>();
            alreadyBoughtOverlay.gameObject.SetActive(config.IsOwned);
            Refresh();
        }

        public void Refresh()
        {
            _button.enabled = _price > spentableResource.CurrentResource == false && _shopItemConfig.IsOwned == false;
            notEnoughCoinsOverlay.gameObject.SetActive(_price > spentableResource.CurrentResource && _shopItemConfig.IsOwned == false);
            alreadyBoughtOverlay.gameObject.SetActive(_shopItemConfig.IsOwned);
        }

        public void Select()
        {
            _shopExplorer.DeselectAllItems();
            _isSelected = true;
            selectedOverlay.gameObject.SetActive(true);
        }

        public void Deselect()
        {
            selectedOverlay.gameObject.SetActive(false);
            _isSelected = false;
        }

        public void Buy()
        {
            if (_price > spentableResource.CurrentResource) return;

            PlayerSave.Instance.SetItemBought(_shopItemConfig.name);
            _shopItemConfig.Load();
            _shopExplorer.DeselectAllItems();
            spentableResource.RemoveResource(_price);
        }

        private void OnDestroy()
        {
            spentableResource.OnChange.RemoveListener(Refresh);
        }
    }
}