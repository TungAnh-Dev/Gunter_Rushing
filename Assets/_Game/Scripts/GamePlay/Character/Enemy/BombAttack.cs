using UnityEngine;
using UnityUtils;

public class BombAttack : MonoBehaviour, IAttack
{
    IEntity enemy;
    public const float Particle_Height = 2.5f;
    void Start()
    {
        enemy = GetComponent<IEntity>();
    }

    public void OnAttack(Vector3 target)
    {
        Explode();
        //enemy.SetHealth(0f);
        enemy.OnDeath();
    }

    private void Explode()
    {
        ParticlePool.Play(ParticleType.Bomb, transform.position.With(y:Particle_Height), Quaternion.identity);
    }

}