using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.GameLogic
{
    public class ShopKeeper : MonoBehaviour
    {
        // Keeper Name is used as a Config Key
        [SerializeField] private string keeperName;

        public string KeeperName { get => keeperName; }

        private void OnTriggerEnter2D(Collider2D other)
        {
            var player = other.GetComponent<Player>();

            if (player == null) return;

            InfoPopupController.Instance.transform.position = transform.position + transform.up * 2f + transform.right * -0.5f;
            InfoPopupController.Instance.Show(keeperName);
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            var player = other.GetComponent<Player>();

            if (player == null) return;

            InfoPopupController.Instance.Hide();
        }
    }
}