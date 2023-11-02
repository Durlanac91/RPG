using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.GameLogic.UI
{
    public class UIPanelShop : MonoBehaviour
    {
        public static UIPanelShop Instance;
        [SerializeField] private GameObject content;
        private ShopExplorer _shopExplorer;

        public ShopExplorer ShopExplorer { get => _shopExplorer; }

        private void Awake()
        {
            if (Instance == null)
                Instance = this;
            else
                Destroy(gameObject);
        }

        private void Start()
        {
            _shopExplorer = GetComponentInChildren<ShopExplorer>(true);
        }

        public void Show()
        {
            content.SetActive(true);
        }
    }
}