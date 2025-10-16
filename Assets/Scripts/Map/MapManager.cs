using UnityEngine;

public class MapManager : MonoBehaviour
{
    [SerializeField] GameObject crossPf;
    [SerializeField] Camera cam;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        float xPos = AppState.Instance.playerPos.x;
        float yPos = AppState.Instance.playerPos.y;
        Vector3 spawnPosition = new Vector3(xPos, yPos, 0f);
        Quaternion rotation = Quaternion.Euler(0f, 45f, 0f);

        Vector3 cameraPos = spawnPosition + new Vector3(1.5f, 40, -20);
        Instantiate(crossPf, spawnPosition, rotation);
        cam.transform.position = cameraPos;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
