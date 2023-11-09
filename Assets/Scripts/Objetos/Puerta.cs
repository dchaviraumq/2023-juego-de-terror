using System;
using Scripts.Contratos;
using UnityEngine;

namespace Objetos
{
    public class Puerta : MonoBehaviour, I_Interactuable
    {
        public string TextoDeInteraccion => abierta ? "Cerrar" : "Abrir";

        [SerializeField] private bool abierta;

        [SerializeField] private Animator _animator;

        public void Interactuar() {
            abierta = !abierta;
            if (abierta)
            {
                Abrir();
            }
            else
            {
                Cerrar();   
            }
        }

        private void Abrir() {
            _animator.ResetTrigger("Close");
            _animator.SetTrigger("Open");
        }

        private void Cerrar() {
            _animator.ResetTrigger("Open");
            _animator.SetTrigger("Close");
        }
    }
}