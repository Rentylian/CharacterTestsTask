using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] 
    private Image _health;
    
    public void SetHealth(float percentHealth)
    {
        _health.fillAmount = percentHealth / 100;
    }
}
