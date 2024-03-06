using UnityEngine;

[CreateAssetMenu(fileName = "FlameThrower", menuName = "ScriptableObjects/Spells/FlameThrower", order = 1)]
public class FlameThrowerSpell : SpellStrategy
{
    public override void CastSpell(Transform origin)
    {
        Flame_Thrower flame_Thrower = SimplePool.Spawn<Flame_Thrower>(PoolType.FlameThrower, origin.position, Quaternion.identity);
        
    }
}