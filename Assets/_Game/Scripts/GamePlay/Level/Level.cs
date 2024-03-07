using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Level : MonoBehaviour
{
    public string levelName;
    Vector3 startPointPlayer;
    [SerializeField] LevelLoader levelLoader;
    [SerializeField] NavMeshSurface navMeshSurface;
    public Vector3 StartPointPlayer { get => startPointPlayer; }
    [SerializeField] WaveSpaner waveSpaner;
    public WaveSpaner WaveSpaner { get => waveSpaner; }

    public void OnInit()
    {
        levelLoader.LoadLevel(levelName);
        startPointPlayer = levelLoader.StartPointPlayer;
        BakeNavMeshSurface();
        waveSpaner.OnInit();
    }

    private void BakeNavMeshSurface()
    {
        navMeshSurface.BuildNavMesh();
    }

    public int TotalNumberOfWavesEnemy() => waveSpaner.TotalNumberOfWaves();
    public int CurrentWave() => waveSpaner.CurrentWave();
}