using System;
using Unity.VisualScripting;
using UnityEngine;

namespace Environment
{
    public class LightSwitch : MonoBehaviour, IInteractable
    {
        [SerializeField] private Light[] lights;
        [SerializeField] private bool    isOn;

        [HideInInspector] [SerializeField] private string interactionText;

        public string InteractionText => isOn ? "Turn Off" : "Turn On";

        private void Awake() => ToggleLights();

        public void Interact() {
            isOn = !isOn;
            ToggleLights();
        }

        private void ToggleLights() {
            foreach (var theLight in lights)
            {
                theLight.enabled = isOn;
            }
        }
    }
}