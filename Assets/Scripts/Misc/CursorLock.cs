using UnityEngine;

namespace Misc
{
    public class CursorLock : MonoBehaviour
    {
        [SerializeField] private KeyCode cursorLockKey = KeyCode.Escape;

        private void Awake() {
            ToggleCursorLock();
        }

        private void Update() {
            if (Input.GetKeyDown(cursorLockKey))
            {
                ToggleCursorLock();
            }
        }

        private void ToggleCursorLock() {
            var isLocked = Cursor.lockState == CursorLockMode.Locked;
            Cursor.lockState = isLocked ? CursorLockMode.None : CursorLockMode.Locked;
        }
    }
}