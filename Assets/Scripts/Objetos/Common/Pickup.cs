using Scripts.Contratos;
using UnityEngine;
using UnityEngine.Events;

namespace Objetos.Common
{
    public class Pickup : MonoBehaviour, I_Interactuable
    {
        public string TextoDeInteraccion => "Pickup";

        [SerializeField] private UnityEvent eventos;

        public void Interactuar() {
            eventos?.Invoke();
        }
    }
}