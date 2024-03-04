using UnityEngine;

public class Projectile : GameUnit
{
    [SerializeField] protected WeaponData weaponData;
    protected float projectileSpeed;
    private float damge;
    protected Vector3 target;

    public float Damge { get => damge;}

    void Awake()
    {
        projectileSpeed = weaponData.muzzleVelocity;
        damge = weaponData.damage;
    }
    public virtual void OnInit(Vector3 target)
    {
        TF.forward = (target - TF.position).normalized;
        this.target = target;
    }

    public virtual void Launch(Vector3 target)
    {

    }

    public void OnDespawn()
    {
        SimplePool.Despawn(this);
    }


}