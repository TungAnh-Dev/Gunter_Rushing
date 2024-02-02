using UnityEngine;
using System.Collections.Generic;

public class Character : AbCharacter
{
    protected Anim anim;
    List<Character> targets = new List<Character>();
    protected Character target;
    public bool IsDead { get; protected set; }
    public override void OnInit()
    {
        anim = GetComponent<Anim>();
    }
    
    public override void OnAttack()
    {
        
    }

    public override void OnDeath()
    {

    }

    public override void OnDespawn()
    {

    }

    public virtual void AddTarget(Character target)
    {
        targets.Add(target);
    }

    //xoas muc tieu
    public virtual void RemoveTarget(Character target)
    {
        targets.Remove(target);
        this.target = null;
    }

    public Character GetTargetInRange()
    {
        Character target = null;
        float minDistance = float.PositiveInfinity;

        for (int i = 0; i < targets.Count; i++)
        {
            //if (targets[i] != null && targets[i] != this && !targets[i].IsDead && Vector3.Distance(TF.position, targets[i].TF.position) <= ATT_RANGE)
            if (targets[i] != null && targets[i] != this)
            {
                float dis = Vector3.Distance(TF.position, targets[i].TF.position);

                if (dis < minDistance)
                {
                    minDistance = dis;
                    target = targets[i];
                }
            }
        }

        return target;
    }


}