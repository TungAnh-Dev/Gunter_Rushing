using UnityEngine;

public class Orbital_Beam_Attack : MonoBehaviour, IAttack
{
    [SerializeField] AttackArea attackArea;
    Vector3 target;
    public void OnAttack(Vector3 target)
    {
        this.target = target;
        OrbitalBeam(target);
        Invoke(nameof(ActivateAttackAreaAfter), 0.5f);
    }

    private void OrbitalBeam(Vector3 target)
    {
        ParticlePool.Play(ParticleType.Orbital_Beam_Red, target, Quaternion.Euler(-90f, 0f, 0f));
    }

    private void ActivateAttackAreaAfter()
    {
        attackArea.TeleportTo(target);
    }
}
