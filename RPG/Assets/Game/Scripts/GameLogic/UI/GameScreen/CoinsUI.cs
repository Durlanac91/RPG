using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Game.GameLogic.UI
{
    public class CoinsUI : MonoBehaviour
    {
        [SerializeField] private SpentableResource spentableResource;
        [SerializeField] private TextMeshProUGUI text;

        void Start()
        {
            spentableResource.OnChange.AddListener(Refresh);
            Refresh();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                spentableResource.AddResource(100);
            }
            else if (Input.GetKeyDown(KeyCode.R))
            {
                spentableResource.RemoveResource(100);
            }
        }

        private void Refresh()
        {
            text.text = spentableResource.CurrentResource.ToString();
        }

        private void OnDestroy()
        {
            spentableResource.OnChange.RemoveListener(Refresh);
        }
    }
}