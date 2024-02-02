using UnityEngine;

public class Laser : Projectile
{
    public override void OnInit(Vector3 target)
    {
        base.OnInit(target);
        ResetTransform();
        this.target = target;
    }

    private void ResetTransform()
    {
        TF.localPosition = Vector3.zero;

        TF.localRotation = Quaternion.identity;

        TF.localScale = Vector3.one;
    }


}