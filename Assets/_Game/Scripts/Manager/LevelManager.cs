using System.Collections.Generic;
using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{
    Vector3 startPoint;
    [SerializeField] Level[] levels;
    [SerializeField] Player player;
    Player currentPlayer;
    Level currentLevel;
    int levelIndex;
    public Level CurrentLevel { get => currentLevel;}
    public Player CurrentPlayer { get => currentPlayer;}

    public List<Enemy> enemies = new List<Enemy>();
    private List<IMenuObserver> observers = new List<IMenuObserver>();

    public void AddObserver(IMenuObserver observer)
    {
        observers.Add(observer);
    }

    public void RemoveObserver(IMenuObserver observer)
    {
        observers.Remove(observer);
    }

    public void NotifyMenuEvent()
    {
        foreach (var observer in observers)
        {
            observer.OnMenuEvent();
        }
    }
    
    public void Setup(int levelIndex)
    {
        OnLoadLevel(levelIndex);
        currentPlayer = Instantiate(player, startPoint, Quaternion.identity);
        currentPlayer.OnInit();
    }

    private void OnLoadLevel(int levelIndex)
    {
        DestroyCurrentLevel();
        currentLevel = Instantiate(levels[levelIndex]);
        currentLevel.OnInit();
        startPoint = currentLevel.StartPointPlayer;
    }

    private void DestroyCurrentLevel()
    {
        if (currentLevel != null)
        {
            Destroy(currentLevel.gameObject);
        }
    }

    public void NextLevel()
    {
        levelIndex++;
        OnLoadLevel(levelIndex);
    }

    public void AddEnemyToList(Enemy newEnemy)
    {
        enemies.Add(newEnemy);
        currentPlayer.AddTarget(newEnemy);
    }

    public void RemoveEnemyToList(Enemy oldEnemy)
    {
        enemies.Remove(oldEnemy);
        currentPlayer.RemoveTarget(oldEnemy);
    }

    public bool AllEnemyDead() => enemies.Count <= 0;


    public void OnMenu()
    {
        NotifyMenuEvent();
        DestroyCurrentLevel();
        UIManager.Instance.CloseAll();
        UIManager.Instance.OpenUI<UI_MainMenu>();
    }

    public void OnVictory()
    {
        Invoke(nameof(Victory), 3f);
    }

    private void Victory()
    {
        DestroyCurrentLevel();
        DestroyPlayer();

        UIManager.Instance.CloseAll();
        UIManager.Instance.OpenUI<UI_Victory>();
    }

    private void DestroyPlayer()
    {
        if(currentPlayer != null)
        {
            Destroy(currentPlayer?.gameObject);
            currentPlayer = null;
        }
        
    }

    public void OnFail()
    {
        GameManager.Instance.ChangeState(GameState.Fail);
        Invoke(nameof(Fail), 3f);
    }

    private void Fail()
    {
        NotifyMenuEvent();
        DestroyCurrentLevel();
        UIManager.Instance.CloseAll();
        UIManager.Instance.OpenUI<UI_Fail>();
    }
}