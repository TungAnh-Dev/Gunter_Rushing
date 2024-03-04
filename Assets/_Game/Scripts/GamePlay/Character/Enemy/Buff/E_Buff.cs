using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public abstract class E_Buff : Enemy
{
    public const float Buff_Time_Delay = 0.5f;
    Enemy target;
    protected override void IdleState(ref Action onEnter, ref Action onExecute, ref Action onExit)
    {
        float ramdonTime = Random.Range(0.5f, 1f); 
        float idleTimer = 0f;
        onEnter = () =>
        {
            idleTimer = 0f; 
            anim.ChangeAnim(Constants.ANIM_IDLE);
        };

        onExecute = () =>
        {
            idleTimer += Time.deltaTime;

            if (idleTimer >= ramdonTime)
            {
                stateMachine.ChangeState(PatrolState);
            }
        };

    }

    protected override void PatrolState(ref Action onEnter, ref Action onExecute, ref Action onExit)
    {
        float ramdonTime = Random.Range(1.5f, 2f); 
        float patrolTimer = 0f;
        onEnter = () =>
        {
            anim.ChangeAnim(Constants.ANIM_RUN);

            RandomDestination();

            patrolTimer = 0f;
        };

        onExecute = () =>
        {
            patrolTimer += Time.deltaTime;

            if (patrolTimer >= ramdonTime)
            {
                stateMachine.ChangeState(BuffState);
            }

        };
    }

    protected void BuffState(ref Action onEnter, ref Action onExecute, ref Action onExit)
    {
        float buffTimer = 0f;
        onEnter = () =>
        {
            anim.ChangeAnim(Constants.ANIM_ATTACK);
            buffTimer = 0f;
            BuffEnemyAround();
        };

        onExecute = () =>
        {
            buffTimer += Time.deltaTime;

            if (buffTimer >= timeToResetAttack)
            {
                stateMachine.ChangeState(IdleState);
            }

        };
    }

    private void BuffEnemyAround()
    {
        Collider[] collider = Physics.OverlapSphere(TF.position, rangeVision);
        foreach (Collider item in collider)
        {
            Enemy enemy = Cache.GetEnemy(item);
            if(enemy != null)
            {
                target = enemy;
                Invoke(nameof(BuffEnemy), Buff_Time_Delay);
            }
        }
    }

    private void BuffEnemy()
    {
        if(target == null) return;

        ParticlePool.Play(ParticleType.Buff_Green, TF.position, Quaternion.Euler(-90f, 0f, 0f));
        target.PlayHealParticle();
        target.GetHealthComponent().IncreaseHealthByPercentage(damage);
    }






    

}