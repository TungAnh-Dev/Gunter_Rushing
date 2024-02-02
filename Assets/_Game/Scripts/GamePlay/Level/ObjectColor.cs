using UnityEngine;

public class ObjectColor : MonoBehaviour
{
    [SerializeField] private Renderer rd;
    public char symbol;


    public void ChangeColor(MapData colorData)
    {
        if(rd != null)
        {
            rd.material = colorData.MainColor;
        }
        
    }

    public void Initialization(Vector3 position, Transform parent, MapData colorData)
    {
        Instantiate(this, position, Quaternion.identity, parent);
        ChangeColor(colorData);
    }
}