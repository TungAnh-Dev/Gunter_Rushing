
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : GameUnit, IEntity
{
    protected Anim anim;
    protected HealthComponent health;
    [SerializeField] protected List<IOnDeathObserver> onDeathObservers = new List<IOnDeathObserver>();

    public virtual void OnInit()
    {
        if(anim == null)
        {
            anim = GetComponent<Anim>();
        }

        if(health == null)
        {
            health = GetComponent<HealthComponent>();
            
        }

        health.OnInit();
    }
    public virtual void OnDeath()
    {
        // Logic xử lý khi chết
        anim.ChangeAnim(Constants.ANIM_DEATH);
        OnDeathObserver();
    }

    public virtual void OnDespawn()
    {
        SimplePool.Despawn(this);
    }

    public virtual float GetHealth()
    {
        return 0;
    }

    public virtual float GetDamage()
    {
        return 0;
    }

    public void SetHealth(float hp)
    {
        health.currrentHp = hp;
    }

    public virtual void OnDeathObserverAdd(IOnDeathObserver observer)
    {
        onDeathObservers.Add(observer);
    }

    protected virtual void OnDeathObserver()
    {
        foreach (IOnDeathObserver observer in this.onDeathObservers)
        {
            observer.OnDeath();
        }
    }

    public HealthComponent GetHealthComponent()
    {
        return health;
    }
}
