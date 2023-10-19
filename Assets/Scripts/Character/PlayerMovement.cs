using System;
using UnityEngine;

namespace Character
{
    [SelectionBase]
    [RequireComponent(typeof(CharacterController))]
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float speed        = 5f;
        [SerializeField] private float jumpStrength = 4f;
        [SerializeField] private float gravity      = Physics.gravity.y;


        private CharacterController _characterController;

        private Vector3 _moveDirection;

        private void Awake() {
            _characterController = GetComponent<CharacterController>();
        }

        private void Update() {
            var x    = Input.GetAxis("Horizontal");
            var jump = Input.GetButtonDown("Jump");
            var z    = Input.GetAxis("Vertical");

            var zMovement = z * speed;
            var xMovement = x * speed;
            var yMovement = _moveDirection.y;

            // Jump or apply gravity
            if (jump && _characterController.isGrounded)
            {
                yMovement = jumpStrength;
            }
            else if (!_characterController.isGrounded)
            {
                yMovement += gravity * Time.deltaTime;
            }

            _moveDirection   = new Vector3(xMovement, 0, zMovement);
            _moveDirection   = transform.TransformDirection(_moveDirection);
            _moveDirection.y = yMovement;

            _characterController.Move(_moveDirection * Time.deltaTime);
        }
    }
}