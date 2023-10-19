using Character;
using Contracts;
using UnityEngine;

namespace Items
{
    public class Flashlight : MonoBehaviour, IInteractable, IPickup
    {
        [SerializeField] private KeyCode flashlightKey = KeyCode.F;

        [SerializeField] private Light        lightBulb;
        [SerializeField] private MeshRenderer glass;

        [SerializeField] private bool isOn;

        [SerializeField] private Material onMaterial;
        [SerializeField] private Material offMaterial;

        [SerializeField] private string interactionText;

        public string InteractionText => interactionText;

        private void Awake() {
            ToggleFlashlight();
        }

        private void Update() {
            if (!Input.GetKeyDown(flashlightKey)) return;

            isOn = !isOn;
            ToggleFlashlight();
        }

        private void ToggleFlashlight() {
            lightBulb.enabled = isOn;
            var mat = isOn ? onMaterial : offMaterial;
            glass.material = mat;
        }

        public void Interact() {
            gameObject.SetActive(false);
        }

        public void Pickup(PlayerItemManager itemManager) {
            itemManager.EnableFlashlight();
        }
    }
}