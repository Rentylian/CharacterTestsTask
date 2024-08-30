using System.Collections;
using UnityEngine;
using Code.Common;

public class InputHandler : MonoBehaviour
{
    public KeyCode KeyCodeInteraction => _keyCodeInteraction;
    [SerializeField]
    private KeyCode _keyCodeInteraction = KeyCode.E;
    private readonly string _horizontalAxis = "Horizontal";
    private readonly string _verticalAxis = "Vertical";
    private Vector2 _movementDir;
    private Events _events;

    public void SetEvents(Events events)
    {
        _events = events;
    }
    
    void Start()
    {
        StartCoroutine(HandleInput());
    }
    
    private IEnumerator HandleInput()
    {
        while(true)
        {
            HandleMovement();
            HandleInteract();
            yield return null;
        }
    }

    private void HandleMovement()
    {
        _movementDir.x = Input.GetAxis(_horizontalAxis);
        _movementDir.y = Input.GetAxis(_verticalAxis);
        if (_movementDir.magnitude > 0)
        {
            _events.EventMove(_movementDir);
        }
    }

    private void HandleInteract()
    {
        if(Input.GetKeyDown(_keyCodeInteraction)){
            _events.EventInteract();
        }
    }
    
}
