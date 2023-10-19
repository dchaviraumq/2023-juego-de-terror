using Character;
using Contracts;
using UnityEngine;
using UnityEngine.Events;

namespace Items.Common
{
    public class ItemPickup : MonoBehaviour, IPickup
    {
        [SerializeField] private string interactionText;

        [SerializeField] private UnityEvent onPickup;

        public string InteractionText => interactionText;

        public void Interact() => onPickup?.Invoke();
    }
}