using UnityEngine;

[CreateAssetMenu(fileName = "CleaveSpell", menuName = "ScriptableObjects/Spells/CleaveSpell", order = 1)]
public class ProjectileSpell : SpellStrategy
{
    public PoolType poolType;
    public override void CastSpell(Transform origin)
    {
        
    }

    class ProjectileBuilder
    {
        private PoolType poolType;
        private float speed;
        private float durarion;

        public ProjectileBuilder WithProjectilePool(PoolType poolType)
        {
            this.poolType = poolType;
            return this;
        }

        public ProjectileBuilder WithSpeed(float speed)
        {
            this.speed = speed;
            return this;
        }

        public ProjectileBuilder WithDuration(float durarion)
        {
            this.durarion = durarion;
            return this;
        }

        // public GameObject Build(Transform origin)
        // {
        //     Vector3 insPositon = origin.position;

        //     Charged_Sphere fireball = SimplePool.Spawn<Charged_Sphere>(poolType, insPositon, Quaternion.identity);
        //     ParticleM
        // }
    }
}