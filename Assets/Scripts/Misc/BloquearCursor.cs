using UnityEngine;

namespace Scripts.Misc
{
    public class BloquearCursor : MonoBehaviour
    {
        [SerializeField] private KeyCode teclaDeBloqueo = KeyCode.Escape;

        private void Awake() {
            ModificarBloqueo();
        }

        private void Update() {
            if (!Input.GetKeyDown(teclaDeBloqueo)) return;
            ModificarBloqueo();
        }

        private void ModificarBloqueo() {
            var estaBloqueado = Cursor.lockState == CursorLockMode.Locked;

            Cursor.lockState = estaBloqueado ? CursorLockMode.None : CursorLockMode.Locked;
        }
    }
}