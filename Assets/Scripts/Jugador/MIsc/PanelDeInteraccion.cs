using TMPro;
using UnityEngine;

namespace Jugador.MIsc
{
    public class PanelDeInteraccion : MonoBehaviour
    {
        [SerializeField] private GameObject fondo;
        [SerializeField] private TMP_Text   etiqueta;

        public void Activar(string texto) {
            fondo.SetActive(true);
            etiqueta.text = texto;
        }


        public void Desactivar() {
            etiqueta.text = string.Empty;
            fondo.SetActive(false);
        }
    }
}