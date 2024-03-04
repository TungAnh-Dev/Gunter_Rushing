
public interface IEntity
{
    void OnDeath();
    void OnDespawn();
    float GetHealth();
    float GetDamage();
    void OnDeathObserverAdd(IOnDeathObserver observer);
    HealthComponent GetHealthComponent();

}