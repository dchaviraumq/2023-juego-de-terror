﻿using System;
using Environment;
using TMPro;
using UnityEngine;

namespace Character
{
    public class PlayerInteraction : MonoBehaviour
    {
        [SerializeField] private KeyCode interactKey = KeyCode.E;

        [SerializeField] private TMP_Text interactionText;

        private IInteractable _interactable;

        private void Update() {
            if (!Input.GetKeyDown(interactKey)) return;
            _interactable?.Interact();
        }

        private void OnTriggerStay(Collider other) {
            // Debug.Log($"OnTriggerStay: {other.name}");
            _interactable = other.gameObject.GetComponent<IInteractable>();
            if (_interactable == null) return;

            interactionText.text = _interactable.InteractionText;
        }

        private void OnTriggerExit(Collider other) {
            // Debug.Log($"OnTriggerExit: {other.name}");
            _interactable        = null;
            interactionText.text = string.Empty;
        }
    }
}