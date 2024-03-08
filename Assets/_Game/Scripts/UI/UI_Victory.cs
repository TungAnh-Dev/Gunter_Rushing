using UnityEngine;

public class UI_Victory : UICanvas
{
    public override void Open()
    {
        base.Open();
        GameManager.Instance.ChangeState(GameState.Victory);
    }

    public void MenuButton()
    {
        LevelManager.Instance.OnMenu();
        Close(0f);
    }
}