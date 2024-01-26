using UnityEngine;

public class GrenadeLauncher : Launcher
{
    public override void Launch(Vector3 target)
    {
        Projectile grenade = SimplePool.Spawn<Projectile>(PoolType.P_Grenade, projectilePoint.position, Quaternion.identity);
        grenade.Launch(target);
    }
}