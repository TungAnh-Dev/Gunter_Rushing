using UnityEngine;

public class ShurikenLauncher : Launcher
{
    public override void Launch(Vector3 target)
    {
        Projectile shuriken = SimplePool.Spawn<Projectile>(PoolType.P_Shuriken, projectilePoint.position, Quaternion.identity);
        shuriken.OnInit(target);
    }
}