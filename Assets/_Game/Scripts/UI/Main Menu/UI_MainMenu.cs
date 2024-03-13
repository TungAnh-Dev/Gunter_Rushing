using UnityEngine;

public class UI_MainMenu : UICanvas
{
    [SerializeField] LevelSelectMenu levelSelectMenu;
    public override void Open()
    {
        base.Open();
        GameManager.Instance.ChangeState(GameState.MainMenu);
        levelSelectMenu.InactiveLevelSelectMenu();
    }

    public void LoadLevel(int levelIndex)
    {
        LevelManager.Instance.Setup(levelIndex);
        Close(0f);
        UIManager.Instance.OpenUI<UI_GamePlay>();
    }

    public void StartBtn()
    {
        levelSelectMenu.ActiveLevelSelectMenu();
        levelSelectMenu.Setup();
    }

    public void QuitBtn() => Application.Quit();
}