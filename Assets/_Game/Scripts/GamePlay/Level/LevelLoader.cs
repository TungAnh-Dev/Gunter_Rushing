using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    public float spacing = 1.0f; // Khoảng cách giữa các đối tượng
    [SerializeField] Transform waterParent; // parent object wall
    [SerializeField] Transform groundParent; // parent object ground
    [SerializeField] Transform propsParent; // parent object props
    [SerializeField] Transform startPointMap; // start point's map

    Vector3 startPointPlayer;

    public Vector3 StartPointPlayer { get => startPointPlayer;}
    private ITile tile;

    public void LoadLevel(string fileName, MapData mapData)
    {
        TextAsset textAsset = Resources.Load<TextAsset>("Map/" + fileName);

        if (textAsset != null)
        {
            string[] lines = textAsset.text.Split('\n');

            for (int y = 0; y < lines.Length; y++)
            {
                string line = lines[y].Trim();

                for (int x = 0; x < line.Length; x++)
                {
                    char symbol = line[x];
                    Vector3 position = new Vector3(x * spacing, 0f, y * spacing) + startPointMap.position; // control positon

                    switch (symbol)
                    {
                        case '9':
                            startPointPlayer = position; // player position
                            Instantiate(mapData.GetTile(TileType.Tile_Center), position, Quaternion.identity, groundParent); 
                            break;
                        
                        case '8':
                            Instantiate(mapData.GetTile(TileType.Tile_Water), position, Quaternion.identity, waterParent); // water
                            break;
                        
                        case '1':
                            Instantiate(mapData.GetTile(TileType.Tile_Center), position, Quaternion.identity, groundParent);
                            break;

                        case '2':
                            Instantiate(mapData.GetTile(TileType.Tile_Center), position, Quaternion.identity, propsParent);
                            break;

                        // Add more cases for other symbols if needed

                        default:
                            // Handle default case if necessary
                            break;
                    }
                }
            }
        }
        else
        {
            Debug.LogError("File not found: " + fileName);
        }
    }

}
