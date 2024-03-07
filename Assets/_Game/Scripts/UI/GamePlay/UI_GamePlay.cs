using TMPro;
using UnityEngine;
using DG.Tweening;

public class UI_GamePlay : UICanvas
{
    [SerializeField] Display_Gameplay display_Gameplay;
    public override void Setup()
    {
        base.Setup();
        display_Gameplay.OnInit();
    }
}
