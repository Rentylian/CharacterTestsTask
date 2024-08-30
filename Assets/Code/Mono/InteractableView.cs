using UnityEngine;
using Code.Common;

namespace Code.Mono
{
    public class InteractableView : MonoBehaviour
    {
        public float InteractableValue => _interactableValue;
        public Transform Transform => _transform;
        public InteractiveType InteractiveType => _currentInteractiveType;
        
        [SerializeField]
        private Transform _transform;
        [SerializeField]
        private InteractiveType _currentInteractiveType;
        [SerializeField] 
        private Renderer _renderer;
        [SerializeField] 
        private Material _highlighted;
        [SerializeField] 
        private float _interactableValue;
        
        private Material _default;
        private bool _isCharacterInteracted;

        private void Awake()
        {
            _default = _renderer.material;
        }

        public void CharacterInteraction()
        {
            if (_isCharacterInteracted)
            {
                ChangeMaterial(_default);
            }
            else
            {
                ChangeMaterial(_highlighted);
            }
        }

        private void ChangeMaterial(Material material)
        {
            _renderer.material = material;
            _isCharacterInteracted = !_isCharacterInteracted;
        }

        public void SetActiveState(bool state)
        {
            gameObject.SetActive(state);
        }
    }
}