using System;
using UnityEngine;

namespace Character
{
    public class MouseRotation : MonoBehaviour
    {
        [SerializeField] private float mouseSensitivityX = 2f;
        [SerializeField] private bool  invertX           = false;

        [SerializeField] private float mouseSensitivityY = 2f;
        [SerializeField] private bool  invertY           = false;
        [SerializeField] private float yClamp            = 45f;

        private int InvertX => invertX ? -1 : 1;
        private int InvertY => invertY ? -1 : 1;

        private Vector2 _turn = Vector2.zero;

        private void Update() {
            _turn.x += Input.GetAxis("Mouse X") * InvertX * mouseSensitivityX;
            _turn.y += -Input.GetAxis("Mouse Y") * InvertY * mouseSensitivityY;
            
            _turn.y = Mathf.Clamp(_turn.y, -yClamp, yClamp);

            transform.localRotation = Quaternion.Euler(_turn.y, _turn.x, 0);
        }
    }
}