using UnityEngine;
using UnityEngine.AI;

public abstract class BaseEnemy : Character
{
    [SerializeField] protected NavMeshAgent navMeshAgent;
}