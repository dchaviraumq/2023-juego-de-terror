using Scripts.Contratos;
using UnityEngine;
using UnityEngine.Events;

namespace Objetos.Common
{
    public class Pickup : MonoBehaviour, I_Interactuable
    {
        [TextArea] 
        [SerializeField] private string textoDeInteraccion;

        [Space(5)] 
        [SerializeField] private bool desapareceAlInteractuar = true;

        [Space(5)] 
        [SerializeField] private UnityEvent onInteract;

        public string TextoDeInteraccion => textoDeInteraccion;

        public void Interactuar() {
            onInteract?.Invoke();
            gameObject.SetActive(!desapareceAlInteractuar);
        }
    }
}