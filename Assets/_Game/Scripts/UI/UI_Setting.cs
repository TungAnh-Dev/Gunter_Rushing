using UnityEngine;

public class UI_Setting : UICanvas
{
    public override void Open()
    {
        base.Open();
        GameManager.Instance.ChangeState(GameState.Setting);
        Time.timeScale = 0;
    }

    public override void Close(float delayTime)
    {
        Time.timeScale = 1;
        base.Close(0f);
    }

    public void ContinueButton()
    {
        Close(0f);
    }

    public void MenuButton()
    {
        LevelManager.Instance.OnMenu();
        Close(0f);
    }

}