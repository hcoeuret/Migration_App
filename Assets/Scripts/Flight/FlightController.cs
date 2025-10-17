using UnityEngine;

public class FlightController : MonoBehaviour
{
    [SerializeField] Camera cam;
    [SerializeField] FlightUIManager uiManager;
    [SerializeField] private BirdDatabase birdDatabase;
    private GameObject spawnbird = null;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cam.transform.position = new Vector3(0, 16, 0);
        cam.transform.rotation = Quaternion.Euler(-46f, 0f, 0f);
        if (spawnbird != null)
        {
            Destroy(spawnbird);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HandleEndOfFLight(bool success)
    {
        //Generate new bird (dead bird if failure)
        BirdType generatedBird;
        if (success)
        {
            AppState.Instance.playerPos = AppState.Instance.futurePos;
            if (Random.Range(0, 10) > 3)
            {
                generatedBird = BirdType.Mallard;
                AppState.Instance.playerBirds.Add(generatedBird);
            }
            else
            {
                generatedBird = BirdType.Eagle;
                AppState.Instance.playerBirds.Add(generatedBird);
            }
        }
        else
        {
            generatedBird = BirdType.Dead;
            AppState.Instance.playerBirds.Add(generatedBird);
        }
        //Switch Camera to new bird background
        cam.transform.position = new Vector3(0, 0, 48.6f);
        cam.transform.rotation = Quaternion.Euler(0f, 0f, 0f);

        //Display prefab of new bird and make it rotate
        Instantiate(birdDatabase.GetBirdPrefab(generatedBird), new Vector3(0f, 0f, 73.4f), Quaternion.identity);

        //Switch panel
        uiManager.ShowEndOfFlight(generatedBird);
    }

    public void SwitchToFlightMain()
    {
        AppManager.Instance.SwitchToMapScene();
    }
}
