using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "BirdDatabase", menuName = "Bird/BirdDatabase")]
public class BirdDatabase : ScriptableObject
{
    public List<BirdData> birds;

    public GameObject GetBirdPrefab(BirdType btype)
    {
        foreach (var bird in birds)
        {
            if (bird.type == btype) return bird.prefab;
        }
        Debug.LogWarning($"Bird type '{btype}' not found in the database!");
        return null;
    }
}
