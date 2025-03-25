using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class HUDController : MonoBehaviour
{
    [FormerlySerializedAs("_stateText")] [SerializeField] private TextMeshProUGUI stateText;

    public static HUDController Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        
        Instance = this;
    }

    public void UpdateStateText(string stateText)
    {
        if (this.stateText)
        {
            this.stateText.text = stateText;
        }
    }
}