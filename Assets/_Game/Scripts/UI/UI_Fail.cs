using UnityEngine;

public class UI_Fail : UICanvas
{
    public override void Open()
    {
        base.Open();
        GameManager.Instance.ChangeState(GameState.Fail);
    }

    public void MenuButton()
    {
        LevelManager.Instance.OnMenu();
        Close(0f);
    }

}

