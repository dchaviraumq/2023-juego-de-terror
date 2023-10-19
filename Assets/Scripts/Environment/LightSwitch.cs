using System;
using Unity.VisualScripting;
using UnityEngine;

namespace Environment
{
    public class LightSwitch : MonoBehaviour, IInteractable
    {
        [SerializeField] private Light[]        lights;
        [SerializeField] private MeshRenderer[] lightBulbs;


        [SerializeField] private Material onMaterial;
        [SerializeField] private Material offMaterial;

        [SerializeField] private bool isOn;

        [HideInInspector] [SerializeField] private string interactionText;

        public string InteractionText => isOn ? "Turn Off" : "Turn On";

        private void Awake() => Toggle();

        public void Interact() {
            isOn = !isOn;
            Toggle();
        }

        private void Toggle() {
            ToggleLights();
            ToggleMaterial();
        }

        private void ToggleLights() {
            foreach (var theLight in lights)
            {
                theLight.enabled = isOn;
            }
        }

        private void ToggleMaterial() {
            var mat = isOn ? onMaterial : offMaterial;
            foreach (var lightBulb in lightBulbs)
            {
                lightBulb.material = mat;
            }
        }
    }
}