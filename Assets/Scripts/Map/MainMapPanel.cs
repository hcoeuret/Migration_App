using UnityEngine;
using UnityEngine.UI;

public class MainMapPanel : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private Button startFlightButton;
    void Start()
    {
        startFlightButton.onClick.AddListener(AppManager.Instance.SwitchToFlyScene);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
