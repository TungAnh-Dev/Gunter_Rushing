
using Cysharp.Threading.Tasks;
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

    private async void Start()
    {
        OnInit();

    }

    public async void OnInit()
    {
        UIManager.Instance.OpenUI<UI_MainMenu>();
        await UIManager.Instance.OpenUI_Delay<UI_Setting>(3);
        
        await UIManager.Instance.WaitForScreenToClose<UI_Setting>();

        // Các công việc tiếp theo sau khi CloseUI_Delay đã hoàn thành
        Debug.Log("CloseUI_Delay đã hoàn thành!");
    }
}