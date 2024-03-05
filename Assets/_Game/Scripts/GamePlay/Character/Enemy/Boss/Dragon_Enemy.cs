using UnityEngine;

public class Dragon_Enemy : E_Boss
{
    [SerializeField] Transform muzzle;
    public static readonly Vector3 Heart = new Vector3(0f, 1f, 0f);
    public override Vector3 GetHeart()
    {
        return Heart + TF.position;
    }

    protected override void OnAttack()
    {
        ProjectileAttack();
        // phun lua
        //loc xoay
    }

    #region Projectile Attack
    private void ProjectileAttack()
    {
        isAttacking = true;

        TF.LookAt(player.TF);


        attack?.OnAttack(player.GetHeart());

        anim.ChangeAnim(Constants.ANIM_PROJECTILE_ATTACK);
        Invoke(nameof(CastSpellProjectile), 0.25f);

        Invoke(nameof(ResetAttack), timeToResetAttack);
    }

    private void CastSpellProjectile()
    {
        spells[0].CastSpell(muzzle);
        Invoke(nameof(ActiveAttackArea), 0.1f);
    }
    #endregion

    // private void TorAttack()
    // {
    //     isAttacking = true;

    //     TF.LookAt(player.TF);


    //     attack?.OnAttack(player.GetHeart());

    //     anim.ChangeAnim(Constants.ANIM_PROJECTILE_ATTACK);
    //     Invoke(nameof(CastSpellProjectile), 0.25f);

    //     Invoke(nameof(ResetAttack), timeToResetAttack);
    // }

    // private void CastSpellProjectile()
    // {
    //     spells[0].CastSpell(muzzle);
    //     Invoke(nameof(ActiveAttackArea), 0.1f);
    // }
}