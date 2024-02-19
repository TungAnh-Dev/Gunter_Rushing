

public abstract class Character : GameUnit, IEntity
{
    protected Anim anim;
    protected HealthComponent health;

    public HealthComponent Health { get => health;}

    public virtual void OnInit()
    {
        anim = GetComponent<Anim>();
        health = GetComponent<HealthComponent>();
        health.OnInit();
    }
    public virtual void OnDeath()
    {
        // Logic xử lý khi chết
        anim.ChangeAnim(Constants.ANIM_DEATH);
        health.HealthBar.OnDespawn();
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
}
