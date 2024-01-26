using UnityEngine;

public class ObjectColor : MonoBehaviour
{
    [SerializeField] private MapData colorData;
    [SerializeField] private Renderer rd;
    public char symbol;

    void Start()
    {
        if(rd != null)
        {
            colorData = LevelManager.Instance.CurrentLevel.LevelLoader.MapData;
            ChangeColor();
        }
        
    }

    public void ChangeColor()
    {
        rd.material = colorData.MainColor;
    }

    public void Initialization(Vector3 position, Transform parent)
    {
        Instantiate(this, position, Quaternion.identity, parent);
    }
}