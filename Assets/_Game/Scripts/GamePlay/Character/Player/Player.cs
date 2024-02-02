
using UnityEngine;

public class Player : Character
{
    public Level level;
    public Weapon[] currentWeapon = new Weapon[4];
    [SerializeField] Transform[] weaponPosition;
    PlayerAutoAttack playerAutoAttack;

    void Start()
    {
        playerAutoAttack = GetComponent<PlayerAutoAttack>();
        currentWeapon[0] = SimplePool.Spawn<Weapon>(PoolType.G_RevolvingGrenade, weaponPosition[0]);
        //currentWeapon[1] = SimplePool.Spawn<Weapon>(PoolType.G_Shuriken, weaponPosition[1]);
        playerAutoAttack.UpdateWeapon(currentWeapon[0]);
        //playerAutoAttack.UpdateWeapon(currentWeapon[1]);
    }
    public override void OnInit()
    {
        base.OnInit();
        TF.position = LevelManager.Instance.StartPoint;
    }


}
