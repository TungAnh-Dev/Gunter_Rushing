using UnityEngine;

public class BulletLauncher : Launcher
{
    public override void Launch(Vector3 target)
    {
        Projectile bullet = SimplePool.Spawn<Projectile>(PoolType.P_Bullet, projectilePoint.position, Quaternion.identity);
        bullet.OnInit(target);
    }
}