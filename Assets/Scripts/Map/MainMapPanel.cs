using UnityEngine;
using UnityEngine.UI;

public class MainMapPanel : MonoBehaviour, IPanel
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private Button startFlightButton;
    MapUIManager mapUIManager;
    void Start()
    {
        mapUIManager = GetComponent<MapUIManager>();

        if (AppManager.Instance != null)
        {
            Debug.Log("App Manager found");
            startFlightButton.onClick.AddListener(SetupButton);
        }
        else
        {
            // AppManager not ready yet, wait a frame
            Debug.Log("AppManager not found");
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowPanel(object arg)
    {
        //Do nothing
    }

    void SetupButton()
    {
        Debug.Log("Button was clicked");
        AppManager.Instance.SwitchToFlyScene();
        AppState.Instance.counter = 60;
        
    }
}
