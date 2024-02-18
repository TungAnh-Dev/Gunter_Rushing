using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] float spacing = 1.0f; // Khoảng cách giữa các đối tượng
    [SerializeField] Transform tileParent; // parent object ground
    [SerializeField] Transform propsParent; // parent object props
    [SerializeField] Transform startPointMap; // start point's map
    private ObjectColor[] tiles;
    private ObjectColor[] props;
    [SerializeField] MapData mapData;


    Vector3 startPointPlayer;

    public Vector3 StartPointPlayer { get => startPointPlayer;}

    void Awake()
    {
        tiles = mapData.Tiles;
        props = mapData.Props;
    }

    public void LoadLevel(string fileName)
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

                    if(symbol == '9')
                    {
                        startPointPlayer = position; // player position
                        Instantiate(tiles[0], position, Quaternion.identity, tileParent);
                    }
                    else
                    {
                        for(int i =0; i < tiles.Length; i++)
                        {
                            if(tiles[i].symbol == symbol)
                            {
                                tiles[i].Initialization(position, tileParent, mapData);
                            }
                            
                        }
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
