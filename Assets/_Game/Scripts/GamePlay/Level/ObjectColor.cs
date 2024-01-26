using UnityEngine;

public class ObjectColor : MonoBehaviour, ITile
{
    [SerializeField] private MapData colorData;
    [SerializeField] private Renderer rd;
    public char symbol;

    void Start()
    {
        colorData = LevelManager.Instance.CurrentLevel.MapData;
        ChangeColor();
    }

    public void ChangeColor()
    {
        rd.material = colorData.MainColor;
    }

    public void Initialization(char symbol, ObjectColor objectColor)
    {
        if(this.symbol == symbol)
        {
            Instantiate(objectColor);
        }
    }
}