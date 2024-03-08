using System;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : GameUnit, IOnDeathObserver, IMenuObserver
{
    [SerializeField] Image imageFill;
    Vector3 offset;
    float hp;
    float maxHP;
    private Transform target;
    IEntity entity;

    void Update()
    {
        if(!GameManager.Instance.IsState(GameState.GamePlay)) return;
        
        imageFill.fillAmount = Mathf.Lerp(imageFill.fillAmount, hp / maxHP, Time.deltaTime*5f);
        transform.position = target.position + offset;
    }

    public void OnInit(IEntity entity,float maxHP, Transform target, Vector3 offset)
    {
        this.offset = offset;
        this.target = target;
        this.maxHP = maxHP;
        hp = maxHP;
        this.entity = entity;

        entity.GetHealthComponent().OnHealthChange += SetNewHp;

        imageFill.fillAmount = 1;
        RegisterOnDeathEvent();
        RegisterOnMenuEvent();
        
    }

    public void SetNewHp(float hp)
    {
        this.hp = hp;
        //imageFill.fillAmount = hp / maxHP;
    }

    public void OnDespawn()
    {
        SimplePool.Despawn(this);
    }

    public void SetColor(Color color)
    {
        imageFill.color = color;
    }

    public void OnDeath()
    {
        OnDespawn();
    }

    protected virtual void RegisterOnDeathEvent()
    {
        entity.OnDeathObserverAdd(this);
    }

    void OnDisable()
    {
        entity.GetHealthComponent().OnHealthChange -= SetNewHp;
    }

    public void OnMenuEvent()
    {
        OnDespawn();
    }

    private void RegisterOnMenuEvent()
    {
        LevelManager.Instance.AddObserver(this);
    }
}