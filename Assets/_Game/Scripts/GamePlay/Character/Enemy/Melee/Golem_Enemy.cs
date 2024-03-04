using UnityEngine;

public class Golem_Enemy : E_Melee
{
    [SerializeField] AttackArea attackArea2;
    public static readonly Vector3 Heart = new Vector3(0f, 1.3f, 0f);
    public const float Atctive_AttackArea2 = 0.5f;
    public override void OnInit()
    {
        base.OnInit();
        attackArea2.InactiveAttackArea();
    }
    public override Vector3 GetHeart()
    {
        return Heart + TF.position;
    }

    protected override void OnAttack()
    {
        isAttacking = true;
        
        TF.LookAt(player.TF);

        anim.ChangeAnim(Constants.ANIM_ATTACK);
        
        ActiveAttackArea();
        attack?.OnAttack(player.TF.position);

        Invoke(nameof(ActiveAttackArea2), Atctive_AttackArea2);

        Invoke(nameof(ResetAttack), enemyData.TimeToResetAttack);
    }

    private void ActiveAttackArea2()
    {
        attackArea2.ActiveAttackArea();
    }

    protected override void ResetAttack()
    {
        base.ResetAttack();
        attackArea2.InactiveAttackArea();
    }

}