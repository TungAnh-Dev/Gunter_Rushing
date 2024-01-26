
public class Constants 
{
    public const string ANIM_RUN = "run";
    public const string ANIM_IDLE = "idle";
    //public const string ANIM_DANCE = "dance";

    public const string TAG_ENEMY = "Enemy";
    public const string WEAPON_SHOOT = "shoot";
}

public enum TileType
{
    Tile_Center = 0, 
    Tile_Center_Foundation = 1, // No surface
    Tile_Corner = 2,
    Tile_Corner_Foundation = 3,
    Tile_Road_Solo = 4,
    Tile_Road_Solo_Corner = 5,
    Tile_Water = 6,
}

public enum PropsType
{
    cabin = 0,
    flower = 1,
    grass = 2,
    Nature_Detail_Edge = 3,
    rock4 = 4,
    shrub = 5,
    stone1 = 6,
    tree = 7,
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
    P_Shuriken = PoolType.P_Shuriken,
    P_Bullet = PoolType.P_Bullet,
    P_Grenade = PoolType.P_Grenade,
    P_Flame = PoolType.P_Flame,
}