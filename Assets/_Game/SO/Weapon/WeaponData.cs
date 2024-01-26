using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponData", menuName = "ScriptableObjects/WeaponData", order = 1)]
public class WeaponData : ScriptableObject
{
    public new string name;
    public float damage;
    public float range;
    public float fireRate;
    public float muzzleVelocity;
    public ProjectileType projectileType;
}




