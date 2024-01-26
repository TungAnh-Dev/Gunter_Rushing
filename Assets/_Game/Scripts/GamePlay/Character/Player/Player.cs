
using UnityEngine;

public class Player : Character
{
    public Level level;
    public Weapon currentWeapon;
    public Transform position;
    void Start()
    {
        currentWeapon = SimplePool.Spawn<Weapon>(PoolType.G_RevolvingGrenade, position);
    }
    public override void OnInit()
    {
        base.OnInit();
        TF.position = LevelManager.Instance.StartPoint;
    }


}
