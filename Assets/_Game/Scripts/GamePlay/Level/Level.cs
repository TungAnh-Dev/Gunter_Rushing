using UnityEngine;
using UnityEngine.AI;

public class Level : MonoBehaviour
{
    public string levelName;
    Vector3 startPointPlayer;
    [SerializeField] LevelLoader levelLoader;
    [SerializeField] NavMeshSurface navMeshSurface;

    public Vector3 StartPointPlayer { get => startPointPlayer; }

    public void OnInit()
    {
        levelLoader.LoadLevel(levelName);
        startPointPlayer = levelLoader.StartPointPlayer;
        BakeNavMeshSurface();
    }

    private void BakeNavMeshSurface()
    {
        navMeshSurface.BuildNavMesh();
    }
}