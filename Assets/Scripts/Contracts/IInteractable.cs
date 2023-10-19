namespace Contracts
{
    public interface IInteractable
    {
        public string InteractionText { get; }

        // public string GetInteractionText();

        public void Interact();
    }
}