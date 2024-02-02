using UnityEngine;

public class Level : MonoBehaviour
{
    public string levelName;
    Vector3 startPointPlayer;
    [SerializeField] LevelLoader levelLoader;

    public Vector3 StartPointPlayer { get => startPointPlayer; }

    public void OnInit()
    {
        levelLoader.LoadLevel(levelName);
        startPointPlayer = levelLoader.StartPointPlayer;
    }
}