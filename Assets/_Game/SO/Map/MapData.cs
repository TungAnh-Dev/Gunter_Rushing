
using UnityEngine;

[CreateAssetMenu(fileName = "MapData", menuName = "ScriptableObjects/MapData", order = 1)]
public class MapData : ScriptableObject
{
    [SerializeField] GameObject[] tiles;
    [SerializeField] GameObject[] props;
    [SerializeField] Material mainColor;

    public Material MainColor { get => mainColor; }

    public GameObject GetProps(PropsType propsType)
    {
        return props[(int)propsType];
    } 

    public GameObject GetTile(TileType tileType)
    {
        return tiles[(int)tileType];
    }

}
