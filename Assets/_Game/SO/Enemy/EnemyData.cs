
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "ScriptableObjects/EnemyData", order = 1)]
public class EnemyData : ScriptableObject
{
    [SerializeField] new string name;
    [SerializeField] float damage;
    [SerializeField] float moveSpeed;
    [SerializeField] float rangeVision;
    [SerializeField] float rangeAttack;
    [SerializeField] float health;
    [SerializeField] float wanderRadius;
    [SerializeField] float timeToResetAttack;
    [SerializeField] float timeToDespawn;

    public string Name { get => name;  }
    public float Damage { get => damage;  }
    public float MoveSpeed { get => moveSpeed;  }
    public float RangeVision { get => rangeVision;  }
    public float RangeAttack { get => rangeAttack; }
    public float Health { get => health;  }
    public float WanderRadius { get => wanderRadius;  }
    public float TimeToResetAttack { get => timeToResetAttack; }
    public float TimeToDespawn { get => timeToDespawn; }
}
