using Code.Common;
using Code.Mono;

namespace Code.Base
{
    public class InteractiveAidKit : InteractiveModule
    {
        private readonly Character _character;
        private bool _isInteractReady;
        private InteractableView _currentInteractable;
        
        public InteractiveAidKit(Character character) : base(character)
        {
            _character = character;
        }

        public override void Initialize()
        {
            _character.Events.InteractHandler += Interact;     
        }

        public override bool CheckInteractive(InteractableView interactableView)// Толкнуть сюда ивент?
        {
            if (interactableView.InteractiveType == InteractiveType.AidKit)
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
                _characterParameters?.IncreaseAidCount((int)_currentInteractable?.InteractableValue);
                _character.Events.EventChangeHint(false);
                _currentInteractable.SetActiveState(false);
                _isInteractReady = false;
                _currentInteractable = null;
            }
        }
    }
}