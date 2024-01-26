
using UnityEngine;

[CreateAssetMenu(fileName = "MapData", menuName = "ScriptableObjects/MapData", order = 1)]
public class MapData : ScriptableObject
{
    [SerializeField] ObjectColor[] tiles;
    [SerializeField] ObjectColor[] props;
    [SerializeField] Material mainColor;

    public Material MainColor { get => mainColor; }
    public ObjectColor[] Tiles { get => tiles;  }
    public ObjectColor[] Props { get => props; }



}
