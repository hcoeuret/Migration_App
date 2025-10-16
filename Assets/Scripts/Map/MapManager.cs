using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class MapManager : MonoBehaviour
{
    [SerializeField] GameObject crossPf;
    [SerializeField] GameObject crossFuturePf;
    private GameObject currentFutureCross;
    [SerializeField] Camera cam;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] Vector3 curPos = new Vector3(0,0,0);
    public event Action<int> OnDistanceChanged;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        float xPos = AppState.Instance.playerPos.x;
        float yPos = AppState.Instance.playerPos.y;
        Vector3 curPos = new Vector3(xPos, yPos, 0f);
        Quaternion rotation = Quaternion.Euler(0f, 45f, 0f);

        Vector3 cameraPos = curPos + new Vector3(0, 40, -20);
        Instantiate(crossPf, curPos, rotation);
        cam.transform.position = cameraPos;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (EventSystem.current.IsPointerOverGameObject())
            {
                // The click is on a UI button
                return; // ignore raycast
            }

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(ray.origin, ray.direction * 100f, Color.red, 4f);
            if (Physics.Raycast(ray, out RaycastHit hit, 100f, groundLayer))
            {
                Vector3 clickPos = hit.point;
                Debug.Log("Clicked at: " + clickPos);
                Vector3 futurePos = clickPos;
                Quaternion rotation = Quaternion.Euler(0f, 45f, 0f);

                if (currentFutureCross != null)
                {
                    Destroy(currentFutureCross);
                }

                currentFutureCross = Instantiate(crossFuturePf, futurePos, rotation);
                float distance = Vector3.Distance(curPos, futurePos);
                AppState.Instance.counter = (int)distance;
                OnDistanceChanged?.Invoke((int)distance);

            }
        }
    }
}
