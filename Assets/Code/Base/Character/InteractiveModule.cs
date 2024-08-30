using Code.Mono;

namespace Code.Base
{
    public class InteractiveModule : CharacterModule
    {
        private readonly Character _character;
        private InteractiveModule _current;
        
        public InteractiveModule(Character character)
        {
            _character = character;
        }
        
        public override void Initialize()
        {
            _character.CharacterView.InteractionHappened += CheckInteractionPossibility;
            _character.CharacterView.InteractionDiscontinued += InteractionObjectDiscontinued;
        }

        private void InteractionObjectDiscontinued()
        {
            _current = null;
            _character.Events.EventChangeHint(false);
        }
        
        private void CheckInteractionPossibility(InteractableView interactableView)
        {
            foreach (var module in _character.CharacterModules)
            {
                if (module is InteractiveModule interactiveModule)
                {
                    _character.Events.EventChangeHint(true);
                    _current = interactiveModule;
                    _current.CheckInteractive(interactableView);
                }
            }
        }
        
        public virtual bool CheckInteractive(InteractableView interactableView)
        {
            return false;
        }
        
        public virtual void Interact()
        {
            return;
        }
    }
}