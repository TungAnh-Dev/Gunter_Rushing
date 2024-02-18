using TMPro;
using UnityEngine;

public class CombatText : GameUnit
{
    public const float Time_To_Despawn = 1f;
    [SerializeField] TextMeshProUGUI hpText;
    public void OnInit(float damage)
    {
        hpText.text = damage.ToString();
        Invoke(nameof(OnDespawn), Time_To_Despawn);
    }

    public void OnDespawn()
    {
        SimplePool.Despawn(this);
    }
}