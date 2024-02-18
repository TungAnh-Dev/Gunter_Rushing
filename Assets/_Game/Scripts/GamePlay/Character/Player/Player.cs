using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    [SerializeField] PlayerData playerData;
    public Level level;
    public Weapon[] currentWeapon = new Weapon[4];
    [SerializeField] Transform[] weaponPosition;
    PlayerAutoAttack playerAutoAttack;
    List<Enemy> targets = new List<Enemy>();
    private Enemy target;

    void Start()
    {
        playerAutoAttack = GetComponent<PlayerAutoAttack>();
        currentWeapon[0] = SimplePool.Spawn<Weapon>(PoolType.G_Rifle, weaponPosition[0]);
        //currentWeapon[1] = SimplePool.Spawn<Weapon>(PoolType.G_Shuriken, weaponPosition[1]);
        playerAutoAttack.UpdateWeapon(currentWeapon[0]);
        //playerAutoAttack.UpdateWeapon(currentWeapon[1]);
    }
    public override void OnInit()
    {
        base.OnInit();
        TF.position = LevelManager.Instance.StartPoint;
    }


    #region Identify Target
    public virtual void AddTarget(Enemy newTarget)
    {
        if (newTarget != null && newTarget != this && !newTarget.Health.IsDead)
        {
            targets.Add(newTarget);
        }
    }

    public virtual void RemoveTarget(Enemy oldTarget)
    {
        if (oldTarget != null)
        {
            targets.Remove(oldTarget);
            target = null;
        }
    }

    public Enemy GetTargetInRange(float range)
    {
        Enemy resultTarget = null;
        float minDistance = float.PositiveInfinity;

        foreach (Enemy potentialTarget in targets)
        {
            if (IsValidTarget(potentialTarget, range))
            {
                float distance = Vector3.Distance(TF.position, potentialTarget.TF.position);

                if (distance < minDistance)
                {
                    minDistance = distance;
                    resultTarget = potentialTarget;
                }
            }
        }

        return resultTarget;
    }

    private bool IsValidTarget(Enemy potentialTarget, float range)
    {
        return potentialTarget != null && potentialTarget != this && !potentialTarget.Health.IsDead && Vector3.Distance(TF.position, potentialTarget.TF.position) <= range;
    }

    #endregion

    #region Health
    public override void OnDeath()
    {
        base.OnDeath();
        Destroy(gameObject, 1f);
    }

    public override void OnDespawn()
    {
        // Logic xử lý khi despawn
    }

    public override float GetHealth()
    {
        return playerData.Hp;
    }
    #endregion
}
