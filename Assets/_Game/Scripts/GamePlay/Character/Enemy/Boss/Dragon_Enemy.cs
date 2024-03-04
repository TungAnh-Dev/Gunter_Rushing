using UnityEngine;

public class Dragon_Enemy : E_Boss
{
    public static readonly Vector3 Heart = new Vector3(0f, 1f, 0f);
    public override Vector3 GetHeart()
    {
        return Heart + TF.position;
    }

    
}