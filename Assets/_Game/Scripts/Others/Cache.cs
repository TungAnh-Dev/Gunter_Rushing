
using System.Collections.Generic;
using UnityEngine;

public static class Cache
{
    private static Dictionary<Collider, IHit> ihits = new Dictionary<Collider, IHit>();

    public static IHit GetIHit(Collider collider)
    {
        if (!ihits.ContainsKey(collider))
        {
            ihits.Add(collider, collider.GetComponent<IHit>());
        }

        return ihits[collider];
    }

    private static Dictionary<Collider, Character> characters = new Dictionary<Collider, Character>();

    public static Character GetCharacter(Collider collider)
    {
        if (!characters.ContainsKey(collider))
        {
            characters.Add(collider, collider.GetComponent<Character>());
        }

        return characters[collider];
    }

    private static Dictionary<Collider, Enemy> enemies = new Dictionary<Collider, Enemy>();

    public static Enemy GetEnemy(Collider collider)
    {
        if (!enemies.ContainsKey(collider))
        {
            enemies.Add(collider, collider.GetComponent<Enemy>());
        }

        return enemies[collider];
    }


}
