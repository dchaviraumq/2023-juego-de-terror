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

        [SerializeField] private bool encendida;

        private void Start() {
            AlternarEncendido();
        }

        private void Update() {
            if (!Input.GetKeyDown(accion)) return;
            encendida = !encendida;

            AlternarEncendido();
        }

        private void AlternarEncendido() {
            luz.enabled = encendida;
            var material = encendida ? luzPrendida : luzApagada;
            vidrio.material = material;
        }
    }
}