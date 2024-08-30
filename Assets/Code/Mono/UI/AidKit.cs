using TMPro;
using UnityEngine;

public class AidKit : MonoBehaviour
{
    [SerializeField] 
    private TMP_Text _aidKitCount;
    
    public void SetAidKitCount(int count)
    {
        _aidKitCount.text = count.ToString();
    }
}
