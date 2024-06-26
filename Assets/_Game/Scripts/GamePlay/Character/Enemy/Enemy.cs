using System;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public abstract class Enemy : Character, IMenuObserver
{
    [SerializeField] protected NavMeshAgent agent;
    protected StateMachine stateMachine = new StateMachine();
    [SerializeField] protected EnemyData enemyData;
    protected float rangeAttack;
    protected float rangeVision;
    float wanderRadius;
    protected Player player;
    protected IAttack attack;
    protected bool isAttacking;
    [SerializeField] protected AttackArea attackArea;
    protected float timeToResetAttack;
    protected float damage;

    void Start()
    {
        attack = GetComponent<IAttack>();
    }

   
    void Update()
    {
        if(health.IsDead || !GameManager.Instance.IsState(GameState.GamePlay)) return;
        
        stateMachine?.Execute();
    }

    public override void OnInit()
    {
        base.OnInit();
        LoadData();
        agent.isStopped = false;
        stateMachine.ChangeState(IdleState);
        isAttacking = false;
        attackArea?.InactiveAttackArea();
        LevelManager.Instance.AddEnemyToList(this);
        RegisterOnMenuEvent();
    }

    public override float GetHealth() => enemyData.Health;

    public override float GetDamage() => enemyData.Damage;

    public override void OnDeath()
    {
        base.OnDeath();
        agent.isStopped = true;
        Invoke(nameof(OnDespawn), enemyData.TimeToDespawn);
        LevelManager.Instance.RemoveEnemyToList(this);
    }


    private void LoadData()
    {
        timeToResetAttack = enemyData.TimeToResetAttack;
        agent.speed = enemyData.MoveSpeed;
        rangeAttack = enemyData.RangeAttack;
        rangeVision = enemyData.RangeVision;
        wanderRadius = enemyData.WanderRadius;
        player = LevelManager.Instance.CurrentPlayer;
        damage = enemyData.Damage;
    }

    protected void ChaseTarget(Vector3 target)
    {
        anim.ChangeAnim(Constants.ANIM_RUN);
        agent.SetDestination(target);
    }

    public void PlayHealParticle()
             => ParticlePool.Play(ParticleType.HealOnceCylinder, TF.position, Quaternion.Euler(-90f, 0f, 0f));


    #region StateMachine
    protected virtual void IdleState(ref Action onEnter, ref Action onExecute, ref Action onExit)
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

            if(PlayerIsInRange(rangeVision))
            {
                stateMachine.ChangeState(ChaseState);
            }
            else if (idleTimer >= ramdonTime)
            {
                stateMachine.ChangeState(PatrolState);
            }
        };

    }

    protected virtual void PatrolState(ref Action onEnter, ref Action onExecute, ref Action onExit)
    {
        onEnter = () =>
        {
            anim.ChangeAnim(Constants.ANIM_RUN);

            RandomDestination();
        };

        onExecute = () =>
        {
            if(PlayerIsInRange(rangeVision))
            {
                stateMachine.ChangeState(ChaseState);
            }
            else if (HasReachedDestination()) 
            {
                stateMachine.ChangeState(IdleState);
            }

        };
    }

    protected virtual bool PlayerIsInRange(float range)
    {
        float distance = Vector3.Distance(player.TF.position, transform.position);
        return distance <= range;
    }

    private bool HasReachedDestination() 
    {
        return !agent.pathPending
                && agent.remainingDistance <= agent.stoppingDistance
                && (!agent.hasPath || agent.velocity.sqrMagnitude == 0f);
    }

    protected void RandomDestination()
    {
        var randomDirection = Random.insideUnitSphere * wanderRadius;
        randomDirection += TF.position;
        NavMeshHit hit;
        NavMesh.SamplePosition(randomDirection, out hit, wanderRadius, 1);
        var finalPosition = hit.position;

        agent.SetDestination(finalPosition);
    }

    protected virtual void ChaseState(ref Action onEnter, ref Action onExecute, ref Action onExit)
    {
        onExecute = () =>
        {
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


    protected virtual void AttackState(ref Action onEnter, ref Action onExecute, ref Action onExit)
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

    protected virtual void OnAttack()
    {
        isAttacking = true;
        
        TF.LookAt(player.TF);

        anim.ChangeAnim(Constants.ANIM_ATTACK);
        
        ActiveAttackArea();
        attack?.OnAttack(player.GetHeart());
        

        Invoke(nameof(ResetAttack), timeToResetAttack);
        
    }

    protected void ActiveAttackArea() => attackArea?.ActiveAttackArea();

    protected virtual void ResetAttack()
    {
        attackArea?.InactiveAttackArea();
        anim.ResetAnim();
        isAttacking = false;
    }

    protected bool CanAttack()
    {
        return !isAttacking;
    }


    #endregion


    public void OnMenuEvent()
    {
        OnDespawn();
        LevelManager.Instance.RemoveEnemyToList(this);
    }

    private void RegisterOnMenuEvent()
    {
        LevelManager.Instance.AddObserver(this);
    }

}