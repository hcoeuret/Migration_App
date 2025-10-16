using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainMapPanel : MonoBehaviour, IPanel
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private Button startFlightButton;
    [SerializeField] private MapManager mapManager;
    [SerializeField] private TMP_Text distanceText;
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

        distanceText.gameObject.SetActive(false);

    }

    private void OnEnable()
    {
        mapManager.OnDistanceChanged += UpdateDistanceText;
    }

    private void OnDisable()
    {
        mapManager.OnDistanceChanged -= UpdateDistanceText;
    }

    private void UpdateDistanceText(int newScore)
    {
        distanceText.gameObject.SetActive(true);
        distanceText.text = "Travel Time: " + newScore + "s";
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
    }
}
