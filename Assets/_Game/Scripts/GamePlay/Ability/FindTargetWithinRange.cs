using System.Collections.Generic;
using UnityEngine;

public class FindTargetWithinRange : MonoBehaviour
{
    public const float ATT_RANGE = 15f;
    List<Character> targets = new List<Character>();
    private Character target;
    public Character GetTargetInRange()
    {
        Character target = null;
        float distance = float.PositiveInfinity;

        for (int i = 0; i < targets.Count; i++)
        {
            //if (targets[i] != null && targets[i] != this && !targets[i].IsDead && Vector3.Distance(TF.position, targets[i].TF.position) <= ATT_RANGE)
            if (targets[i] != null && targets[i] != this && Vector3.Distance(transform.position, targets[i].TF.position) <= ATT_RANGE)
            {
                float dis = Vector3.Distance(transform.position, targets[i].TF.position);

                if (dis < distance)
                {
                    distance = dis;
                    target = targets[i];
                }
            }
        }

        return target;
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
}