using UnityEngine;

public class Shuriken : Projectile
{
    // public override void OnInit(Vector3 target)
    // {
    //     base.OnInit(target);

    // }

    void Update()
    {
        ShurikenForward();
    }

    private void ShurikenForward()
    {
        TF.Translate(TF.forward * projectileSpeed * Time.deltaTime, Space.World);
    }

    public void OnDespawn()
    {
        SimplePool.Despawn(this);
    }
}