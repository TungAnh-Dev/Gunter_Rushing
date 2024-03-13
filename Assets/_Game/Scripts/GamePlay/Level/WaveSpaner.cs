using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class WaveSpaner : MonoBehaviour
{
    [SerializeField] WaveSO[] waveSO;
    private WaveSO currentWave;
    [SerializeField] Transform[] spawnPoints;
    private float timeDelayAppearWave;
    private float timeDelayAppearWaveCounter;
    private int index = 0;
    private bool stopSpawning;
    private bool isEndLevel;
    [SerializeField] List<IWaveObserver> observers = new List<IWaveObserver>();
    int num, num2;



    void Update()
    {
        if(!GameManager.Instance.IsState(GameState.GamePlay)) return;

        if(CanSpawnWaveEnemy())
        {
            if (timeDelayAppearWaveCounter <= 0)
            {
                SpawnWave();
                IncWave();
                timeDelayAppearWaveCounter = timeDelayAppearWave; 
            }
            else
            {
                timeDelayAppearWaveCounter -= Time.deltaTime; 
            }
        }

        if(IsEndLevel()) 
        {
            OnWaveEndObserver();
            LevelManager.Instance.OnVictory();
            isEndLevel = true;
        }
    }

    public void OnInit()
    {
        index = 0;
        stopSpawning = isEndLevel = false;
        currentWave = waveSO[index];
        LoadTImeDelay();
    }

    private void LoadTImeDelay()
    {
        timeDelayAppearWave = currentWave.timeDelayAppearWave;
        timeDelayAppearWaveCounter = timeDelayAppearWave;
    }

    private void SpawnWave()
    {
        for (int i = 0; i < currentWave.numberToSpawn; i++)
        {
            num = Random.Range(0, currentWave.enemisInWave.Length);
            num2 = Random.Range(0, spawnPoints.Length);

            Enemy newEnemy = SimplePool.Spawn<Enemy>
                            (currentWave.enemisInWave[num].poolType, spawnPoints[num2].position, spawnPoints[num2].rotation);
            newEnemy.OnInit();

        }
        OnWaveStartObserver();
    }

    private void IncWave()
    {
        if(index + 1 < waveSO.Length)
        {
            index++;
            currentWave = waveSO[index];
            LoadTImeDelay();
        }
        else
        {
            stopSpawning = true;
        }
    }

    private bool CanSpawnWaveEnemy() => !stopSpawning && LevelManager.Instance.AllEnemyDead();
    private bool IsEndLevel() => !isEndLevel && LevelManager.Instance.AllEnemyDead() && stopSpawning;

    public int TotalNumberOfWaves() => waveSO.Length;
    public int CurrentWave() => index + 1;

    public virtual void OnWaveStartObserverAdd(IWaveObserver observer)
    {
        observers.Add(observer);
    }

    protected virtual void OnWaveStartObserver()
    {
        foreach (IWaveObserver observer in observers)
        {
            observer.OnWaveStart();
        }
    }

    protected virtual void OnWaveEndObserver()
    {
        foreach (IWaveObserver observer in observers)
        {
            observer.OnWaveEnd();
        }
    }

}