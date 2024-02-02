using UnityEngine;

public class Shuriken : Projectile
{
    void Update()
    {
        ShurikenForward();
    }

    private void ShurikenForward()
    {
        TF.Translate(TF.forward * projectileSpeed * Time.deltaTime, Space.World);
    }

}