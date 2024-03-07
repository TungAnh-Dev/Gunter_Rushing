using System.Collections.Generic;
using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{
    Vector3 startPoint;
    public Vector3 StartPoint { get => startPoint;}
    [SerializeField] Level[] levels;
    [SerializeField] Player player;
    Level currentLevel;
    int levelIndex;
    public Player Player { get => player;}
    public Level CurrentLevel { get => currentLevel;}

    List<Enemy> enemies = new List<Enemy>();
    

    private void Start() 
    {
        levelIndex = 0;
        OnLoadLevel(levelIndex);
        player.OnInit();
        UIManager.Instance.OpenUI<UI_GamePlay>();
    }

    void Update()
    {
        
    }

    private void OnLoadLevel(int levelIndex)
    {
        if(currentLevel != null)
        {
            Destroy(currentLevel.gameObject);
        }

        currentLevel = Instantiate(levels[levelIndex]);
        currentLevel.OnInit();
        startPoint = currentLevel.StartPointPlayer;
    }

    public void NextLevel()
    {
        levelIndex++;
        OnLoadLevel(levelIndex);
    }

    public void AddEnemyToList(Enemy newEnemy)
    {
        enemies.Add(newEnemy);
        player.AddTarget(newEnemy);
    }

    public void RemoveEnemyToList(Enemy oldEnemy)
    {
        enemies.Remove(oldEnemy);
        player.RemoveTarget(oldEnemy);
    }

    public bool AllEnemyDead() => enemies.Count <= 0;




}