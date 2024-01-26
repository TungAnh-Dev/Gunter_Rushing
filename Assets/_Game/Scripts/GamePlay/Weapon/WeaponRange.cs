using UnityEngine;

public class WeaponRange : MonoBehaviour
{
    [SerializeField] SphereCollider sphereCollider;
    [SerializeField] Weapon weapon;
    Character character;
    void Start()
    {
        character = LevelManager.Instance.Player;
        sphereCollider.radius = weapon.range;
    }
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Constants.TAG_ENEMY))
        {
            Character target = Cache.GetCharacter(other);
            //if (!target.IsDead)
            //{
                character.AddTarget(target);
           // }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(Constants.TAG_ENEMY))
        {
            Character target = Cache.GetCharacter(other);
            character.RemoveTarget(target);
        }
    }
}
