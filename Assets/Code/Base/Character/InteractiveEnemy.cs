using Code.Common;
using Code.Mono;

namespace Code.Base
{
    public class InteractiveEnemy : InteractiveModule
    {
        private readonly Character _character;
        private bool _isInteractReady;
        private InteractableView _currentInteractable;
        
        public InteractiveEnemy(Character character) : base(character)
        {
            _character = character;
        }
        
        public override void Initialize()
        {
            _character.Events.InteractHandler += Interact;    
            _character.CharacterView.InteractionDiscontinued += LockInteraction;
        }

        public override bool CheckInteractive(InteractableView interactableView)
        {
            if (interactableView.InteractiveType == InteractiveType.Enemy)
            {
                _currentInteractable = interactableView;
                _isInteractReady = true;
                return true;
            }
            _isInteractReady = false; 
            return false;
        }
        
        public override void Interact()
        {
            if (_isInteractReady)
            {
                CharacterParameters _characterParameters = _character.CharacterModules.Find(x => x is CharacterParameters) as CharacterParameters;
                _characterParameters?.ChangeHealth(_currentInteractable.InteractableValue);
            }
        }

        private void LockInteraction()
        {
            _isInteractReady = false;
        }
    }
}