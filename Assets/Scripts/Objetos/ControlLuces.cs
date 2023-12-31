﻿using System;
using Scripts.Contratos;
using UnityEngine;

namespace Scripts.Objetos
{
    public class ControlLuces : MonoBehaviour, I_Interactuable
    {
        [SerializeField] private Light[]        luces;
        [SerializeField] private MeshRenderer[] focos;

        [SerializeField] private Material luzPrendida;
        [SerializeField] private Material luzApagada;

        [SerializeField] private bool encendido;

        public string TextoDeInteraccion => encendido ? "Apagar" : "Encender";

        private void Awake() {
            AlternarEncendido();
        }

        public void Interactuar() {
            encendido = !encendido;
            AlternarEncendido();
        }

        private void AlternarEncendido() {
            foreach (var luz in luces)
            {
                luz.enabled = encendido;
            }

            var material = encendido ? luzPrendida : luzApagada;
            foreach (var foco in focos)
            {
                foco.material = material;
            }
        }
    }
}