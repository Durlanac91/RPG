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

        public bool IsGameRunning { get => _isGameRunning; }
        public bool IsInputAllowed { get => _isInputAllowed; }

        private void Awake()
        {
            if (Instance == null)
                Instance = this;
            else
                Destroy(gameObject);
        }

        void Start()
        {

        }
    }
}