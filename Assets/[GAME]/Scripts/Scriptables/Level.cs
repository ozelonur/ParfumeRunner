using UnityEngine;

[CreateAssetMenu(fileName = "Level", menuName = "Level", order =1)]
public class Level : ScriptableObject
{
    [SerializeField] private GameObject levelPrefab;

    public GameObject LevelPrefab { get => levelPrefab; set => levelPrefab = value; }
}
