using System;
using Scripts.Contratos;
using UnityEngine;

namespace Objetos
{
    public class Puerta : MonoBehaviour, I_Interactuable
    {
        public string TextoDeInteraccion => abierta ? "Cerrar" : "Abrir";

        [SerializeField] private bool abierta;

        private Animator _animator;

        private static readonly int AbrirTrigger  = Animator.StringToHash("Open");
        private static readonly int CerrarTrigger = Animator.StringToHash("Close");

        private void Start() {
            _animator = GetComponent<Animator>();
        }

        public void Interactuar() {
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
    }
}