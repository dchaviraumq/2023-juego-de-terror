using System;
using Scripts.Contratos;
using UnityEngine;
using UnityEngine.Serialization;

namespace Objetos
{
    public class Puerta : MonoBehaviour, I_Interactuable
    {
        public string TextoDeInteraccion => Mensaje();

        [SerializeField] private bool     conLlave;
        [SerializeField] private Animator animator;

        private bool _abierta;

        public void Interactuar() {
            if (conLlave) return;

            _abierta = !_abierta;
            if (_abierta)
            {
                Abrir();
            }
            else
            {
                Cerrar();
            }
        }

        public void QuitarLlave() {
            conLlave = false;
        }

        private string Mensaje() {
            if (conLlave)
            {
                return "Se necesita una llave";
            }
            else if (_abierta)
            {
                return "Cerrar";
            }
            else
            {
                return "Abrir";
            }
        }

        private void Abrir() {
            animator.ResetTrigger("Close");
            animator.SetTrigger("Open");
        }

        private void Cerrar() {
            animator.ResetTrigger("Open");
            animator.SetTrigger("Close");
        }
    }
}