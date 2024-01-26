
public class Constants 
{
    public const string ANIM_RUN = "run";
    public const string ANIM_IDLE = "idle";
    //public const string ANIM_DANCE = "dance";

    public const string TAG_ENEMY = "Enemy";
    public const string WEAPON_SHOOT = "shoot";
}

public enum WeaponType
{
    G_Shuriken = PoolType.G_Shuriken,
    G_Rifle = PoolType.G_Rifle, // AK47
    G_RevolvingGrenade = PoolType.G_RevolvingGrenade,
    G_Flame = PoolType.G_Flame,
}

public enum ProjectileType
{
    P_Shuriken,
    P_Bullet,
    P_Grenade,
    P_Flame
}