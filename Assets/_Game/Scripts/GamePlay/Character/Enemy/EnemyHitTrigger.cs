using UnityEngine;


public class EnemyHitTrigger : MonoBehaviour
{
    [SerializeField] EnemyData enemyData;
    float damage;
    void Start()
    {
        damage = enemyData.Damage;
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

