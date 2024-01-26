using UnityEngine;

public class Level : MonoBehaviour
{
    public string levelName;
    Vector3 startPointPlayer;
    [SerializeField] MapData mapData;
    [SerializeField] LevelLoader levelLoader;

    public Vector3 StartPointPlayer { get => startPointPlayer; }
    public MapData MapData { get => mapData; }

    public void OnInit()
    {
        levelLoader.LoadLevel(levelName, mapData);
        startPointPlayer = levelLoader.StartPointPlayer;
    }
}