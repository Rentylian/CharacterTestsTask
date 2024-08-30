using Code.Base;
using Code.Common;
using UnityEngine;

public class EntryPoint : MonoBehaviour
{
    [SerializeField]
    private InputHandler _inputHandler;
    [SerializeField]
    private Health _health;
    [SerializeField]
    private AidKit _aidKit;
    [SerializeField]
    private CharacterView _characterView;
    [SerializeField]
    private InteractivesHint _interactivesHint;

    private Character _character;
    private Events _events;
    private SceneHandler _sceneHandler;
    
    void Awake()
    {
        _events = new Events();
        _character = new Character(_characterView, _events);
        _sceneHandler = new SceneHandler();
        _interactivesHint.AddHotKeyHint(_inputHandler.KeyCodeInteraction);
        _inputHandler.SetEvents(_events);
        Addsubscribers();
    }

    private void Addsubscribers()
    { 
        _events.InteractionHintStateChanged += _interactivesHint.SetHintState;
        _events.HealthChanged += _health.SetHealth;
        _events.AidKitChanged += _aidKit.SetAidKitCount;
        _events.LevelRestarted += _sceneHandler.RestartGame;
        
    }
    
    private void OnDestroy()
    {
        _events.InteractionHintStateChanged -= _interactivesHint.SetHintState;
        _events.HealthChanged -= _health.SetHealth;
        _events.AidKitChanged -= _aidKit.SetAidKitCount;
    }
}
