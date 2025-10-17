using UnityEngine;

[CreateAssetMenu(fileName = "BirdData", menuName = "Bird/BirdData")]
public class BirdData : ScriptableObject
{
    public BirdType type;
    public GameObject prefab;
}
