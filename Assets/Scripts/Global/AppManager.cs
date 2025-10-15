using UnityEditor.SearchService;
using UnityEngine.SceneManagement;
using UnityEngine;

public class AppManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public static AppManager Instance { get; private set; }
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject );
            return;
        }

        Instance = this;

        DontDestroyOnLoad(gameObject);

        Initialize();
    }

    // Update is called once per frame
    void Initialize()
    {
        Debug.Log("Initializing Map");
        SceneManager.LoadScene("MapScene");
    }

    public void SwitchToMapScene()
    {
        Debug.Log("Loading Map Scene");
        SceneManager.LoadScene("MapScene");
    }

    public void SwitchToFlyScene()
    {
        Debug.Log("Loading Fly Scene");
        SceneManager.LoadScene("FlightScene");
    }
}
