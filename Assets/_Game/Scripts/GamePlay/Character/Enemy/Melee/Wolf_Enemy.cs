using UnityEngine;

public class Wolf_Enemy : E_Melee
{
    public static readonly Vector3 Heart = new Vector3(0f, 0.5f, 0f);
    public override Vector3 GetHeart()
    {
        return Heart + TF.position;
    }
}