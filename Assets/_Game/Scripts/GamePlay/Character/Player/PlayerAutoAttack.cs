using UnityEngine;

public class PlayerAutoAttack : MonoBehaviour
{
    Weapon currentWeapon;
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

    public void AutoAttack()
    {
        if(currentWeapon == null)
        {
            currentWeapon = player.currentWeapon;
        }
        else
        {
            target = player.GetTargetInRange();
            if(target != null)
            {
                targetPoint = target.TF.position;
                currentWeapon?.Shoot(targetPoint);
                //ChangeAnim(Constant.ANIM_ATTACK);
            }
        }
        
    }

}