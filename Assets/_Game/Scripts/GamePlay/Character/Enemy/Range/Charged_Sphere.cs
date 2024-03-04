using UnityEngine;

public class Charged_Sphere : GameUnit
{
    public const float Move_Speed = 5f;
    [Header("Despawn Settings")]
    [SerializeField] float disLimit = 40f;
    float distance;
    Vector3 target;
    float damage;
    void Update()
    {
        MoveForward();

        DespawnByDistant();
    }

    public virtual void OnInit(Vector3 target, float damage)
    {
        TF.forward = (target - TF.position).normalized;
        this.target = target;
        this.damage = damage;
    }

    protected void MoveForward()
    {
        TF.Translate(TF.forward * Move_Speed * Time.deltaTime, Space.World);
    }

    protected void DespawnByDistant()
    {
        if(CanDespawn())
        {
            OnDespawn();
        }
    }

    protected bool CanDespawn()
    {
        distance = Vector3.Distance(transform.position, target);
        if (distance > disLimit) return true;
        return false;
    }

    private void OnDespawn()
    {
        SimplePool.Despawn(this);
    }

    void OnTriggerEnter(Collider other)
    {
        IHit hit = Cache.GetIHit(other);
        
        if(hit != null)
        {
            hit.OnHit(damage);
        }
    }

    
}