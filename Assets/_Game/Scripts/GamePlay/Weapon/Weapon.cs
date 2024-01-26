using UnityEngine;

public class Weapon : GameUnit
{
    [SerializeField] WeaponData weaponData;
    [SerializeField] Transform projectilePoint;
    Anim anim;
    public float range {get; private set; }
    public float fireRate {get; private set; }
    private float fireRateCooldown;
    void Start()
    {
        anim = GetComponent<Anim>();
        range = weaponData.range;
        fireRate = weaponData.fireRate;
        fireRateCooldown = 0;
    }

    void FixedUpdate()
    {   
        fireRateCooldown += Time.deltaTime;
    }
    
        
    public void Shoot(Vector3 target)
    {
        if(fireRate < fireRateCooldown)
        {
            LookAtTarget(target);
            anim.ChangeAnim(Constants.WEAPON_SHOOT);

            Projectile projectile = SimplePool.Spawn<Projectile>((PoolType)weaponData.projectileType, projectilePoint.position, Quaternion.identity);
            projectile.OnInit(target);
            fireRateCooldown = 0;

            Invoke(nameof(ResetAnim), 0.5f);
        }
    }

    private void LookAtTarget(Vector3 target)
    {
        TF.LookAt(target);
    }

    private void ResetAnim()
    {
        anim.ResetAnim();
    }
}