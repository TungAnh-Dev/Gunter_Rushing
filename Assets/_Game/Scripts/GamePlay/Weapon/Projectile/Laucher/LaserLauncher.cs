using System.Reflection;
using UnityEngine;

public class LaserLauncher : Launcher
{
    Projectile laser = null;
    public override void Launch(Vector3 target)
    {
        if(target == null && laser != null)
        {
            laser.OnDespawn();
            laser = null;
        }
        if(laser != null) return;

        laser = SimplePool.Spawn<Projectile>(PoolType.P_Laser, projectilePoint.position, Quaternion.identity, projectilePoint);
        laser.OnInit(target);

        
    }
}