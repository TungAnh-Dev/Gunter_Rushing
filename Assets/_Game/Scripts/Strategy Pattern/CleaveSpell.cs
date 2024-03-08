
using UnityEngine;

[CreateAssetMenu(fileName = "CleaveSpell", menuName = "ScriptableObjects/Spells/CleaveSpell", order = 1)]
public class CleaveSpell : SpellStrategy
{
    public override void CastSpell(Transform origin)
    {
        Vector3 directionToPlayer = (LevelManager.Instance.CurrentPlayer.TF.position - origin.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(directionToPlayer);
        float angle = lookRotation.eulerAngles.y;

        ParticlePool.Play(ParticleType.Cleave_Fire, origin.position, Quaternion.Euler(-90f, 0f, angle - 90f));
    }

}