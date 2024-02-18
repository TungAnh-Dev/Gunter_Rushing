using UnityEngine;


public class HitTrigger : MonoBehaviour
{
    IEntity entity;
    float damage;
    void Start()
    {
        entity = GetComponentInParent<IEntity>();
        damage = entity.GetDamage();
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

