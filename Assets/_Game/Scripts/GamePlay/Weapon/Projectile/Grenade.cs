using UnityEngine;

public class Grenade : Projectile
{
    [SerializeField] Rigidbody rb;

    public override void OnInit(Vector3 target)
    {
        base.OnInit(target);
        ThrowGrenada(target);
    }

    public void ThrowGrenada(Vector3 target)
    {
        float gravity = Physics.gravity.magnitude;
        float halfFlightTime = Mathf.Sqrt(projectileSpeed * 2f / gravity);

        Vector3 destinationVec = target - TF.position;
        destinationVec.y = 0;
        float horizontalDis = destinationVec.magnitude;

        float upSpeed = halfFlightTime * gravity;
        float fwdSpeed = horizontalDis / (2 * halfFlightTime);

        Vector3 flightVel = Vector3.up * upSpeed + destinationVec.normalized * fwdSpeed;
        rb.AddForce(flightVel, ForceMode.VelocityChange);
    }

    private void Explode()
    {
        SimplePool.Despawn(this);
    }
}
