using System;
using UnityEngine;

public abstract class E_Boss : Enemy
{
    [SerializeField] protected SpellStrategy[] spells; 
    protected override void AttackState(ref Action onEnter, ref Action onExecute, ref Action onExit)
    {
        // onEnter = () =>
        // {
        //     attack?.OnAttack();
        // };

        onExecute = () =>
        {
            if(isAttacking) return;
            
            if(PlayerIsInRange(rangeAttack))
            {
                if(CanAttack())
                {
                    agent.isStopped = true;
                    OnAttack();
                } 
            }
            else
            {
                agent.isStopped = false;
                stateMachine.ChangeState(ChaseState);
            }
        };

        onExit = () =>
        {

        };
    }

}