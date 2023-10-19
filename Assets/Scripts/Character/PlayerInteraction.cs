using System;
using Contracts;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

namespace Character
{
    public class PlayerInteraction : MonoBehaviour
    {
        [FormerlySerializedAs("pickupManager")] [SerializeField]
        private PlayerItemManager itemManager;

        [SerializeField] private KeyCode interactKey = KeyCode.E;

        [SerializeField] private TMP_Text interactionText;

        private IInteractable _interactable;
        private IPickup       _pickup;

        private void Update() {
            if (!Input.GetKeyDown(interactKey)) return;
            _interactable?.Interact();

            if (_pickup == null) return;
            _pickup.Pickup(itemManager);
            interactionText.text = string.Empty;
        }

        private void OnTriggerStay(Collider other) {
            // Debug.Log($"OnTriggerStay: {other.name}");
            _interactable = other.gameObject.GetComponent<IInteractable>();

            if (_interactable == null) return;

            _pickup              = other.gameObject.GetComponent<IPickup>();
            interactionText.text = _interactable.InteractionText;
        }

        private void OnTriggerExit(Collider other) {
            // Debug.Log($"OnTriggerExit: {other.name}");
            _interactable        = null;
            _pickup              = null;
            interactionText.text = string.Empty;
        }
    }
}