using UnityEngine;

public class Flame_Thrower : GameUnit
{
    public void OnDespawn() => SimplePool.Despawn(this);
}