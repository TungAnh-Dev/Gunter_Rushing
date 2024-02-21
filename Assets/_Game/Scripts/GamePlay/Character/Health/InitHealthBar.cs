using UnityEngine;

public class InitHealthBar : MonoBehaviour
{

    HealthBar healthBar;
    [SerializeField] Vector3 offsetHealthBar;
    [SerializeField] Color color;

    public void InitializeHealthBar(IEntity entity,float maxHp)
    {
        healthBar = SimplePool.Spawn<HealthBar>(PoolType.HealthBar);
        healthBar.OnInit(entity, maxHp, transform, offsetHealthBar); 
        healthBar.SetColor(color);
    }
}