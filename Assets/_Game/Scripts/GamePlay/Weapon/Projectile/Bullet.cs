using UnityEngine;

public class Bullet : Projectile
{
    void Update()
    {
        BulletForward();
    }

    private void BulletForward()
    {
        TF.Translate(TF.forward * projectileSpeed * Time.deltaTime, Space.World);
    }


}