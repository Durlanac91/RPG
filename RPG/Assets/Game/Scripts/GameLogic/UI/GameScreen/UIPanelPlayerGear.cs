using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.GameLogic.UI
{
    public class UIPanelPlayerGear : MonoBehaviour
    {
        public static UIPanelPlayerGear Instance;
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