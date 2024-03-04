using UnityEngine;

public class Treant_Enemy : E_Buff
{
    public static readonly Vector3 Heart = new Vector3(0f, 1f, 0f);
    public override Vector3 GetHeart()
    {
        return Heart + TF.position;
    }

}