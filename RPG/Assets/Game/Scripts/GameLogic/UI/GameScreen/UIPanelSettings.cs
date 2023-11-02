using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.GameLogic.UI
{
    public class UIPanelSettings : MonoBehaviour
    {
        public static UIPanelSettings Instance;
        [SerializeField] private GameObject content;

        private void Awake()
        {
            if (Instance == null)
                Instance = this;
            else
                Destroy(gameObject);
        }

        public void Show()
        {
            content.SetActive(true);
        }
    }
}