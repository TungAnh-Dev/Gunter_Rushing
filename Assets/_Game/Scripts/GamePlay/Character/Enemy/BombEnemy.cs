using System;
using UnityEngine;

public class BombEnemy : Enemy
{
    public const float Seft_Destruct = 5f;
    public static readonly Vector3 Heart = new Vector3(0f, 0.5f, 0f);

    protected override void ChaseState(ref Action onEnter, ref Action onExecute, ref Action onExit)
    {
        onEnter = () =>
        {
            Invoke(nameof(SeftDestruct), Seft_Destruct);
        };

        onExecute = () =>
        {
            if(isAttacking) return;
            
            if(PlayerIsInRange(rangeAttack))
            {
                stateMachine.ChangeState(AttackState);
            }
            else
            {
                ChaseTarget(player.TF.position);
            }
        };
    }

    private void SeftDestruct()
    {
        if(Health.IsDead) return;

        OnAttack();
    }

    public override Vector3 GetHeart() => TF.position + Heart;




}