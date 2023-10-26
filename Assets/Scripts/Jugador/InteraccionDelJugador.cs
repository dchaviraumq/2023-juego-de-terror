using System;
using Scripts.Contratos;
using UnityEngine;

namespace Jugador
{
    public class InteraccionDelJugador : MonoBehaviour
    {
        [SerializeField] private KeyCode accion = KeyCode.E;

        private I_Interactuable _interactuable;

        private void Update() {
            if (!Input.GetKeyDown(accion)) return;
            if (_interactuable == null) return;

            _interactuable.Interactuar();
        }

        private void OnTriggerStay(Collider other) {
            _interactuable = other.gameObject.GetComponent<I_Interactuable>();
        }

        private void OnTriggerExit(Collider other) {
            _interactuable = null;
        }
    }
}