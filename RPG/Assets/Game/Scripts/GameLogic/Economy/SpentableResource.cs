using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Game.GameLogic
{
    [CreateAssetMenu(fileName = "SpentableResource", menuName = "Gameplay/Economy/SpentableResource", order = 0)]
    public class SpentableResource : ScriptableObject
    {
        [SerializeField] private string saveKey;

        public UnityEvent OnChange;
        private int _currentResource;

        public int CurrentResource { get => _currentResource; }

        // Used only by GameManager to load resources when game starts
        public void Load()
        {
            _currentResource = PlayerSave.Instance.GetResource(saveKey);
            OnChange?.Invoke();
        }

        public void AddResource(int amount)
        {
            _currentResource += amount;
            PlayerSave.Instance.SetResource(saveKey, _currentResource);
            OnChange?.Invoke();
        }

        public void RemoveResource(int amount)
        {
            _currentResource -= amount;
            PlayerSave.Instance.SetResource(saveKey, _currentResource);
            OnChange?.Invoke();
        }
    }
}