using System;
using Scripts.Contratos;
using UnityEngine;

namespace Objetos
{
    public class Puerta : MonoBehaviour, I_Interactuable
    {
        public string TextoDeInteraccion
        {
            get
            {
                if (locked) return "Esta puerta necesita una llave para abrirse.";
                return abierta ? "Cerrar" : "Abrir";
            }
        }

        [SerializeField] private bool abierta;
        [SerializeField] private bool locked;

        private Animator _animator;

        private static readonly int AbrirTrigger  = Animator.StringToHash("Open");
        private static readonly int CerrarTrigger = Animator.StringToHash("Close");

        private void Start() {
            _animator = GetComponent<Animator>();

            if (!locked) return;
            abierta = false;
            _animator.ResetTrigger(AbrirTrigger);
            _animator.SetTrigger(CerrarTrigger);
        }

        public void Interactuar() {
            if (locked) return;
            
            abierta = !abierta;
            if (abierta)
            {
                _animator.ResetTrigger(CerrarTrigger);
                _animator.SetTrigger(AbrirTrigger);
            }
            else
            {
                _animator.ResetTrigger(AbrirTrigger);
                _animator.SetTrigger(CerrarTrigger);
            }
        }

        public void Unlock() {
            locked = false;
        }
    }
}