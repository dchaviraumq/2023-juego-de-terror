using UnityEngine;

namespace Jugador
{
    public class CamaraJugador : MonoBehaviour
    {
        [SerializeField] private float sensibilidadX = 1f;
        [SerializeField] private float sensibilidadY = 1f;

        [SerializeField] private float limiteY = 45f;

        private Vector2 _rotacion = Vector2.zero;

        private void Update() {
            _rotacion.x += Input.GetAxis("Mouse X");
            _rotacion.y -= Input.GetAxis("Mouse Y");

            _rotacion.x *= sensibilidadX;
            _rotacion.y *= sensibilidadY;

            _rotacion.y = Mathf.Clamp(_rotacion.y, -limiteY, limiteY);

            transform.localRotation = Quaternion.Euler(_rotacion.y, _rotacion.x, 0);
        }
    }
}