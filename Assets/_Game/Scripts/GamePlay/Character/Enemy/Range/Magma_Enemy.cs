using UnityEngine;

public class Magma_Enemy : E_Range
{
    public static readonly Vector3 Heart = new Vector3(0f, 0.5f, 0f);
    public override Vector3 GetHeart()
    {
        return Heart + TF.position;
    }

    protected override void OnAttack()
    {
        isAttacking = true;
        
        TF.LookAt(player.TF);

        anim.ChangeAnim(Constants.ANIM_ATTACK);
        
        attack?.OnAttack(player.TF.position);
        Invoke(nameof(ActiveAttackArea), 1.7f);

        Invoke(nameof(ResetAttack), enemyData.TimeToResetAttack);
    }
}