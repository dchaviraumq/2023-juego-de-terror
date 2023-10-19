using UnityEngine;

namespace Character
{
    public class PlayerItemManager : MonoBehaviour
    {
        [SerializeField] private GameObject flashLight;

        private void Start() {
            flashLight.SetActive(false);
        }

        public void EnableFlashlight() {
            flashLight.SetActive(true);
        }
    }
}