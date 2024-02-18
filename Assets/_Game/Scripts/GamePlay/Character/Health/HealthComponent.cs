using DamageNumbersPro;
using UnityEngine;
using UnityEngine.Events;
using UnityUtils;

public class HealthComponent : MonoBehaviour, IHit
{
    IEntity entity;
    public float currrentHp;
    float maxHP;
    public bool IsDead => currrentHp <= 0;

    HealthBar healthBar;
    public HealthBar HealthBar { get => healthBar;}

    [SerializeField] Vector3 offsetHealthBar;
    [SerializeField] Color color;
    public DamageNumber damageNumber;

    public void OnInit()
    {
        if(entity == null)
        {
            entity = GetComponent<IEntity>();
            maxHP = entity.GetHealth();
        }

        currrentHp = maxHP;
        InitializeHealthBar(maxHP, this.transform, offsetHealthBar);
    }

    public void OnHit(float damage)
    {
        if(!IsDead)
        {
            currrentHp -= damage;

            if(IsDead)
            {
                currrentHp = 0;
                entity.OnDeath();
            }

            healthBar.SetNewHp(currrentHp);
            //SimplePool.Spawn<CombatText>(PoolType.CombatText, transform.position.With(x:1,y:2), Quaternion.identity).OnInit(damage);
            damageNumber.Spawn(transform.position.With(y:1), damage);

        }
    }

    private void InitializeHealthBar(float maxHp, Transform target, Vector3 offset)
    {
        healthBar = SimplePool.Spawn<HealthBar>(PoolType.HealthBar);
        healthBar.OnInit(maxHp, target, offset); 
        healthBar.SetColor(color);
    }
}