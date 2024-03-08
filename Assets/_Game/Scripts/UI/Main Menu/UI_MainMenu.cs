using UnityEngine;

public class UI_MainMenu : UICanvas
{
    public override void Open()
    {
        base.Open();
        GameManager.Instance.ChangeState(GameState.MainMenu);
    }

    public void LoadLevel(int levelIndex)
    {
        LevelManager.Instance.Setup(levelIndex);
        Close(0f);
        UIManager.Instance.OpenUI<UI_GamePlay>();
    }
}