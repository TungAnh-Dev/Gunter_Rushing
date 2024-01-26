using UnityEngine;

public class FlameLauncher : Launcher
{
    public override void Launch(Vector3 target)
    {
        Projectile flame = SimplePool.Spawn<Projectile>(PoolType.P_Flame, projectilePoint.position, Quaternion.identity);
        flame.OnInit(target);
    }
}