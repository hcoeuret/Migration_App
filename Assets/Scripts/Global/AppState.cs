using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class AppState : MonoBehaviour
{
    public static AppState Instance { get; private set; }
    public Vector2 playerPos;
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
        playerPos.x = 0;
        playerPos.y = 0;

        playerBirds = new List<BirdType>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
