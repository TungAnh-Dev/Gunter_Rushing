using UnityEngine;

public class AttackArea : MonoBehaviour
{
    public void ActiveAttackArea()
    {
        gameObject.SetActive(true);
    }

    public void InactiveAttackArea()
    {
        gameObject.SetActive(false);
    }
}