using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAutoAttack : MonoBehaviour
{
    List<Weapon> weapons = new List<Weapon>(4);
    Vector3 targetPoint;
    Character target;
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
        target = player.GetTargetInRange();
        if(target != null)
        {
            targetPoint = target.TF.position;

            foreach (Weapon weapon in weapons)
            {
                weapon?.Shoot(targetPoint);
            }
            //ChangeAnim(Constant.ANIM_ATTACK);
        }
        
    }

}