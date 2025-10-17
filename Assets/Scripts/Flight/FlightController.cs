using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class FlightController : MonoBehaviour
{
    [SerializeField] Camera cam;
    [SerializeField] FlightUIManager uiManager;
    [SerializeField] private BirdDatabase birdDatabase;
    [SerializeField] public Vector3 rotationSpeed = new Vector3(0f, 100f, 0f); // degrees per second
    private GameObject spawnbird = null;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cam.transform.position = new Vector3(125, 11, 480);
        cam.transform.rotation = Quaternion.Euler(28f, -405f, 1f);
        if (spawnbird != null)
        {
            Destroy(spawnbird);
        }
        SpawnBirdList();
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnbird != null)
        {
            spawnbird.transform.Rotate(rotationSpeed * Time.deltaTime);
        }
    }

    void SpawnBirdList()
    {
        int maxDisplay = 6;
        int count = Mathf.Min(AppState.Instance.playerBirds.Count, maxDisplay);
        List<Vector3> positions = new List<Vector3>();
        positions.Add(new Vector3(80f, -12f, 512f));
        positions.Add(new Vector3(90f, -12f, 506f));
        positions.Add(new Vector3(90f, -12f, 518f));
        positions.Add(new Vector3(100f, -12f, 500f));
        positions.Add(new Vector3(100f, -12f, 512f));
        positions.Add(new Vector3(100f, -12f, 524f));

        for (int i = 0; i < count; i++)
        {
            GameObject tempBird = birdDatabase.GetBirdPrefab(AppState.Instance.playerBirds[i]);
            Instantiate(tempBird, positions[i], tempBird.transform.rotation);
        }
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
        GameObject tempBird2 = birdDatabase.GetBirdPrefab(generatedBird);
        spawnbird = Instantiate(tempBird2, new Vector3(0f, 0f, 73.4f), tempBird2.transform.rotation);

        //Switch panel
        uiManager.ShowEndOfFlight(generatedBird);
    }

    public void SwitchToFlightMain()
    {
        AppManager.Instance.SwitchToMapScene();
    }
}
