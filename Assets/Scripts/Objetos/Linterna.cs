using UnityEngine;

namespace Objetos
{
    public class Linterna : MonoBehaviour
    {
        [SerializeField] private KeyCode accion = KeyCode.F;

        [SerializeField] private Light        luz;
        [SerializeField] private MeshRenderer vidrio;

        [SerializeField] private Material luzPrendida;
        [SerializeField] private Material luzApagada;

        [SerializeField] private bool encendido;

        private void Start() {
            // Si inicia apagada: Apagar luz y cambiar  material
            if (encendido)
            {
                luz.enabled     = true;
                vidrio.material = luzPrendida;
            }
            // Si inicia encendida: Encender luz y cambiar material
            else
            {
                luz.enabled     = false;
                vidrio.material = luzApagada;
            }
        }

        private void Update() {
            if (!Input.GetKeyDown(accion)) return;
            encendido = !encendido;
            if (encendido)
            {
                luz.enabled     = true;
                vidrio.material = luzPrendida;
            }
            // Si inicia encendida: Encender luz y cambiar material
            else
            {
                luz.enabled     = false;
                vidrio.material = luzApagada;
            }
        }
    }
}