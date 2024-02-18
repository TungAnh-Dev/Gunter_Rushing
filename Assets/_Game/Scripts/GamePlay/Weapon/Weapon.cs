using UnityEngine;

public class Weapon : GameUnit
{
    [SerializeField] WeaponData weaponData;
    Anim anim;
    public float range {get; private set; }
    public float fireRate {get; private set; }
    private float nextFireTime;
    private ILaucher laucher;
    void Start()
    {
        laucher = GetComponent<ILaucher>();
        anim = GetComponent<Anim>();
        range = weaponData.range;
        fireRate = weaponData.fireRate;
    }

    private bool CanFire() => Time.time >= nextFireTime;
    
        
    public void Shoot(Vector3 target)
    {
        if(CanFire())
        {
            nextFireTime = Time.time + fireRate;

            TF.LookAt(target);
            anim.ChangeAnim(Constants.WEAPON_SHOOT);

            laucher.Launch(target);
            
            anim.ResetAnimAfterSecond(0.5f);
        }
    }


}