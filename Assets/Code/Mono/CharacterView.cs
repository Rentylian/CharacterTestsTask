using System;
using Code.Mono;
using UnityEngine;

public class CharacterView : MonoBehaviour
{
    public Action<InteractableView> InteractionHappened;
    public Action InteractionDiscontinued;
    
    [SerializeField]
    private Rigidbody _rigidbody;
    [SerializeField]
    private float _speed = 3;
    [SerializeField]
    private InteractableView _currentInteractable;
    
    private Vector3 _direction;
    
    public void Move(Vector2 movementDirection)
    {
        _direction = new Vector3(movementDirection.x, 0f, movementDirection.y);
        _rigidbody.AddForce(_direction * (_speed * Time.fixedDeltaTime), ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.TryGetComponent(out InteractableView interactiveView))
        {
            _currentInteractable = interactiveView;
            _currentInteractable.CharacterInteraction();
            InteractionHappened?.Invoke(interactiveView);
        }
    }
    
    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject == _currentInteractable?.gameObject)
        {
            _currentInteractable.CharacterInteraction();
            _currentInteractable = null;
            InteractionDiscontinued?.Invoke();
        }
    }
}
