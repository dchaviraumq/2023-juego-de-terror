namespace Environment
{
    public interface IInteractable
    {
        public string InteractionText { get; }

        // public string GetInteractionText();

        public void Interact();
    }
}