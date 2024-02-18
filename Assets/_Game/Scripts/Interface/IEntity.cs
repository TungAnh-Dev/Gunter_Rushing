
public interface IEntity
{
    void OnDeath();
    void OnDespawn();
    float GetHealth();
    float GetDamage();
    void SetHealth(float hp);
}