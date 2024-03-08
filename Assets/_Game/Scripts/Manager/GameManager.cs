
using UnityEngine;

public enum GameState { MainMenu, GamePlay, Fail, Victory, Setting }

public class GameManager : Singleton<GameManager>
{
    private GameState gameState;

    public void ChangeState(GameState gameState)
    {
        this.gameState = gameState;
    }

    public bool IsState(GameState gameState) => this.gameState == gameState;

    private void Awake()
    {
        
    }

    private void Start()
    {
        UIManager.Instance.OpenUI<UI_MainMenu>();
    }
}