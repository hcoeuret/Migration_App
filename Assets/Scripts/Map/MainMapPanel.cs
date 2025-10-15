using UnityEngine;
using UnityEngine.UI;

public class MainMapPanel : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private Button startFlightButton;
    void Start()
    {
        // Wait for AppManager to be available
        if (AppManager.Instance != null)
        {
            Debug.Log("App Manager found");
            startFlightButton.onClick.AddListener(SetupButton);
        }
        else
        {
            // AppManager not ready yet, wait a frame
            Debug.Log("AppManager not found");
            StartCoroutine(WaitForAppManager());
        }
        
    }

    private System.Collections.IEnumerator WaitForAppManager()
    {
        // Wait until AppManager.Instance is available
        while (AppManager.Instance == null)
        {
            yield return null;
        }
        startFlightButton.onClick.AddListener(SetupButton);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetupButton()
    {
        Debug.Log("Button was clicked");
        AppManager.Instance.SwitchToFlyScene();
        
    }
}
