using System;
using DamageNumbersPro;
using UnityEngine;
using UnityEngine.Events;
using UnityUtils;

public class HealthComponent : MonoBehaviour, IHit, IOnDeathObserver
{
    IEntity entity;
    public float currrentHp;
    float maxHP;
    public bool IsDead => currrentHp <= 0;
    public DamageNumber damageNumber;

    public event Action<float> OnHealthChange;
    InitHealthBar initHealthBar;

    public void OnInit()
    {
        if(initHealthBar == null)
        {
            initHealthBar = GetComponent<InitHealthBar>();
        }

        if(entity == null)
        {
            entity = GetComponent<IEntity>();
            maxHP = entity.GetHealth();
            RegisterOnDeathEvent();
        }
        
        currrentHp = maxHP;
        initHealthBar.InitializeHealthBar(entity, maxHP);
    }

    public void OnHit(float damage)
    {
        if(!IsDead)
        {
            currrentHp -= damage;

            OnHealthChange?.Invoke(currrentHp);

            if(IsDead)
            {
                currrentHp = 0;
                entity.OnDeath();
            }

            //SimplePool.Spawn<CombatText>(PoolType.CombatText, transform.position.With(x:1,y:2), Quaternion.identity).OnInit(damage);
            damageNumber.Spawn(transform.position.With(y:1), damage);

        }
    }

    public void OnDeath()
    {
        currrentHp = 0;
    }

    private void RegisterOnDeathEvent()
    {
        entity.OnDeathObserverAdd(this);
    }
}