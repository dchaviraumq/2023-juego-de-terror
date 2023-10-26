using TMPro;
using UnityEngine;

namespace Jugador.UI
{
    public class PanelDeInteraccionUI : MonoBehaviour
    {
        [SerializeField] private GameObject panel;
        [SerializeField] private TMP_Text   etiqueta;

        private void Start() {
            Ocultar();
        }

        public void Mostrar(string texto) {
            panel.SetActive(true);
            etiqueta.text = texto;
        }

        public void Ocultar() {
            etiqueta.text = string.Empty;
            panel.SetActive(false);
        }
    }
}