using UnityEngine;

public class ProjectileTrigger : MonoBehaviour
{
    [SerializeField] Projectile projectile;
    void OnTriggerEnter(Collider other)
    {
        IHit hit = Cache.GetIHit(other);
        
        if(hit != null)
        {
            hit.OnHit(projectile.Damge);
            projectile.OnDespawn();
        }
    }
}