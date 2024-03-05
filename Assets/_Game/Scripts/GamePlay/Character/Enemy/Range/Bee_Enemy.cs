using UnityEngine;

public class Bee_Enemy : E_Range, IAttack
{
    [SerializeField] SpellStrategy spell;
    [SerializeField] Transform muzzle;
    public static readonly Vector3 Heart = new Vector3(0f, 0.3f, 0f);
    public override Vector3 GetHeart()
    {
        return Heart + TF.position;
    }

    public void OnAttack(Vector3 target)
    {
        spell.CastSpell(muzzle);
    }
}