using UnityEngine;

namespace Jugador
{
    [SelectionBase]
    [RequireComponent(typeof(CharacterController))]
    public class MovimientoJugador : MonoBehaviour
    {
        [SerializeField] private float velocidad   = 5f;
        [SerializeField] private float fuerzaSalto = 4f;
        [SerializeField] private float gravedad    = -9.81f;

        private CharacterController _controller;

        private Vector3 _movimiento;

        private void Start() {
            _controller = GetComponent<CharacterController>();
        }

        private void Update() {
            var saltando = Input.GetButtonDown("Jump");

            var x = Input.GetAxis("Horizontal") * velocidad;
            var y = _movimiento.y;
            var z = Input.GetAxis("Vertical") * velocidad;

            if (saltando && _controller.isGrounded)
            {
                y = fuerzaSalto;
            }
            else if (!_controller.isGrounded)
            {
                y += gravedad * Time.deltaTime;
            }

            var vectorLocal = new Vector3(x, 0, z);
            vectorLocal =  transform.TransformDirection(vectorLocal);
            // vectorLocal *= Time.deltaTime;

            _movimiento = new Vector3(vectorLocal.x, y, vectorLocal.z);

            _controller.Move(_movimiento * Time.deltaTime);
        }
    }
}