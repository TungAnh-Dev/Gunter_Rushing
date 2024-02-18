using System.Collections.Generic;
using UnityEngine;

public class PlayerAutoAttack : MonoBehaviour
{
    List<Weapon> weapons = new List<Weapon>(4);
    Player player;

    void Start()
    {
        player = GetComponent<Player>();
    }

    void Update()
    {
        AutoAttack();
    }

    public void UpdateWeapon(Weapon weapon)
    {
        weapons.Add(weapon);
    }

    public void AutoAttack()
    {
        for (int i = 0; i < weapons.Count; i++)
        {
            float weaponRange = weapons[i]?.range ?? 0f;
            Enemy currentTarget = player.GetTargetInRange(weaponRange);

            if (currentTarget != null)
            {
                weapons[i]?.Shoot(currentTarget.GetHeart());
            }
        }
    }
}
