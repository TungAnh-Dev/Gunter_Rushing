using UnityEngine;

public class PlayerAutoAttack : MonoBehaviour
{
    Weapon currentWeapon;
    public Transform position;
    void Start()
    {
        currentWeapon = SimplePool.Spawn<Weapon>(PoolType.G_Shuriken, position);
    }
    public void OnAttack(Vector3 target)
    {
       currentWeapon?.Shoot(target);
    }

}