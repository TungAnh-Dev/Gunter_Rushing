using UnityEngine;

public class RangeAttack : MonoBehaviour, IAttack
{
    [SerializeField] AttackArea attackArea;
    public void OnAttack(Vector3 target)
    {
        attackArea.TeleportTo(target);
    }
}