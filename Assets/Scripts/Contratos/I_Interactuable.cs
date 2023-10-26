namespace Scripts.Contratos
{
    public interface I_Interactuable
    {
        public string TextoDeInteraccion { get; }
        
        public void Interactuar();
    }
}