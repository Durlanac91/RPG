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

        private SpentableResource[] _spentableResources;
        private ShopItemConfig[] _shopItemConfigs;
        private PlayerGearItemConfig[] _playerGearItemConfig;

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

        public void LoadGame()
        {
            _spentableResources = Resources.LoadAll<SpentableResource>("Configs/Economy");

            foreach (var resource in _spentableResources)
            {
                resource.Load();
            }

            _playerGearItemConfig = Resources.LoadAll<PlayerGearItemConfig>("Configs/PlayerGearItems");

            foreach (var config in _playerGearItemConfig)
            {
                config.Load();
            }
        }
    }
}