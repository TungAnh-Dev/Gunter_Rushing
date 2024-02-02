using UnityEngine;

public class Projectile : GameUnit
{
    [SerializeField] protected WeaponData weaponData;
    protected float projectileSpeed;
    public Vector3 target;
    void Awake()
    {
        projectileSpeed = weaponData.muzzleVelocity;
    }
    public virtual void OnInit(Vector3 target)
    {
        TF.forward = (target - TF.position).normalized;
    }

    public virtual void Launch(Vector3 target)
    {

    }

    public void OnDespawn()
    {
        SimplePool.Despawn(this);
    }


}