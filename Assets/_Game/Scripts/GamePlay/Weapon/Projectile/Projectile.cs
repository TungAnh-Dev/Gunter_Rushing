using UnityEngine;

public class Projectile : GameUnit
{
    [SerializeField] protected WeaponData weaponData;
    protected float projectileSpeed;
    void Awake()
    {
        projectileSpeed = weaponData.muzzleVelocity;
    }
    public virtual void OnInit(Vector3 target)
    {
        TF.forward = (target - TF.position).normalized;
    }
}