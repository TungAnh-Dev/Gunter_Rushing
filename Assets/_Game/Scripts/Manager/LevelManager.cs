
using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{
    Vector3 startPoint;
    public Vector3 StartPoint { get => startPoint;}


    [SerializeField] Level[] levels;
    [SerializeField] Player player;
    Level currentLevel;
    public Level CurrentLevel { get => currentLevel; }
    public Player Player { get => player;}

    private void Start() 
    {
        currentLevel = levels[0];
        currentLevel.OnInit();
        startPoint = currentLevel.StartPointPlayer;
        player.OnInit();
    }
}