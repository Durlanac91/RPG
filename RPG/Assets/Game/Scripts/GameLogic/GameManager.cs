using Game.GameLogic.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Game.GameLogic
{
    [DefaultExecutionOrder(-100)]
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;

        [HideInInspector] public UnityEvent OnGameStart;

        private bool _isGameRunning;
        private bool _isInputAllowed;

        private SpentableResource[] spentableResources;
        private ShopItemConfig[] shopItemConfigs;

        public bool IsGameRunning { get => _isGameRunning; set => _isGameRunning = value; }
        public bool IsInputAllowed { get => _isInputAllowed; set => _isInputAllowed = value; }

        private void Awake()
        {
            if (Instance == null)
                Instance = this;
            else
                Destroy(gameObject);
        }

        void Start()
        {
            LoadGame();
            _isGameRunning = true;
            _isInputAllowed = true;
            OnGameStart?.Invoke();
        }

        private void LoadGame()
        {
            spentableResources = Resources.LoadAll<SpentableResource>("Configs/Economy");

            foreach (var resource in spentableResources)
            {
                resource.Load();
            }

            shopItemConfigs = Resources.LoadAll<ShopItemConfig>("Configs/ShopItems");

            foreach (var config in shopItemConfigs)
            {
                config.Load();
            }
        }
    }
}