using System;
using Jugador.MIsc;
using Scripts.Contratos;
using TMPro;
using UnityEngine;

namespace Jugador
{
    public class InteraccionDelJugador : MonoBehaviour
    {
        [SerializeField] private KeyCode accion = KeyCode.E;

        [SerializeField] private PanelDeInteraccion panelDeInteraccion;


        private I_Interactuable _interactuable;

        private void Start() {
            panelDeInteraccion.Desactivar();
        }

        private void Update() {
            if (!Input.GetKeyDown(accion)) return;
            if (_interactuable == null) return;

            _interactuable.Interactuar();
        }

        private void OnTriggerStay(Collider other) {
            _interactuable = other.gameObject.GetComponent<I_Interactuable>();
            if (_interactuable == null) return;

            var texto = $"[{accion}] {_interactuable.TextoDeInteraccion}";
            panelDeInteraccion.Activar(texto);
        }

        private void OnTriggerExit(Collider other) {
            _interactuable = null;

            panelDeInteraccion.Desactivar();
        }
    }
}