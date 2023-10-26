using System;
using Jugador.UI;
using Scripts.Contratos;
using UnityEngine;

namespace Jugador
{
    public class InteraccionDelJugador : MonoBehaviour
    {
        [SerializeField] private KeyCode              accion = KeyCode.E;
        [SerializeField] private PanelDeInteraccionUI panelDeInteraccionUI;

        private I_Interactuable _interactuable;

        private void Update() {
            if (!Input.GetKeyDown(accion)) return;
            if (_interactuable == null) return;
            _interactuable.Interactuar();
            
            panelDeInteraccionUI.Ocultar();
        }

        private void OnTriggerStay(Collider other) {
            _interactuable = other.gameObject.GetComponent<I_Interactuable>();
            
            var texto = "[" + accion + "] " + _interactuable.TextoDeInteraccion;
            panelDeInteraccionUI.Mostrar(texto);
        }

        private void OnTriggerExit(Collider other) {
            _interactuable = null;
            
            panelDeInteraccionUI.Ocultar();
        }
    }
}