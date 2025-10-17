using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class AppState : MonoBehaviour
{
    public static AppState Instance { get; private set; }
    public Vector3 playerPos;
    public Vector3 futurePos;
    public int counter = 0;
    public List<BirdType> playerBirds;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        DontDestroyOnLoad(gameObject);
        playerPos = new Vector3(0f, 0f, 0f);
        futurePos = new Vector3(0f, 0f, 0f);

        playerBirds = new List<BirdType>();
        playerBirds.Add(BirdType.Mallard);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
