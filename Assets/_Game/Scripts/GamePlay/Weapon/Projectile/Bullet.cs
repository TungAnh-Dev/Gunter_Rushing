using UnityEngine;

public class Bullet : Projectile
{
    [Header("Despawn Settings")]
    [SerializeField] protected float disLimit = 40f;
    protected float distance;
    void Update()
    {
        BulletForward();

        DespawnByDistant();
    }
    protected void BulletForward()
    {
        TF.Translate(TF.forward * projectileSpeed * Time.deltaTime, Space.World);
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


}