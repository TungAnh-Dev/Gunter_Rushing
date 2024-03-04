using UnityEngine;

public class Charged_Sphere_Attack : MonoBehaviour, IAttack
{
    [SerializeField] Transform muzzle;
    IEntity entity;
    void Start()
    {
        entity = GetComponent<IEntity>();
    }

    public void OnAttack(Vector3 target)
    {
        ChargedSphere(target);
    }


    private void ChargedSphere(Vector3 target)
    {
        Charged_Sphere charged_Sphere = 
                        SimplePool.Spawn<Charged_Sphere>(PoolType.ChargeSphere, muzzle.position, Quaternion.identity);
        charged_Sphere.OnInit(target, entity.GetDamage());
    }
}