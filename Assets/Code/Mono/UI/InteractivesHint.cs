using TMPro;
using UnityEngine;

public class InteractivesHint : MonoBehaviour
{
    [SerializeField] 
    private TMP_Text _hint;

    public void AddHotKeyHint(KeyCode keyCode)
    {
        keyCode.ToString();
        _hint.text = $"Press {keyCode.ToString()} to interact with the object";
    }
    
    public void SetHintState(bool state)
    {
        gameObject.SetActive(state);
    }

}
