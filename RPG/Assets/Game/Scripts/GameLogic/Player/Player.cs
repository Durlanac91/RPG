using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Game.GameLogic
{
    public class Player : MonoBehaviour
    {
        public static Player Instance;

        [HideInInspector] public UnityEvent OnGearChange;

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