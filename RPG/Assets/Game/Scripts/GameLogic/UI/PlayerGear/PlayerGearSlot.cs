using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.GameLogic.UI
{
    public class PlayerGearSlot : MonoBehaviour
    {
        [Tooltip("Slot Class is used for classification")]
        [SerializeField] private string slotClass;
        [Tooltip("Slot Type is used for classification")]
        [SerializeField] private string slotType;

        void Start()
        {

        }
    }
}