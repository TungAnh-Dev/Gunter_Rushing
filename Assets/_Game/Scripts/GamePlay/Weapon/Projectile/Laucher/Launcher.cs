using UnityEngine;

public class Launcher : MonoBehaviour, ILaucher
{
    [SerializeField] protected Transform projectilePoint;
    public virtual void Launch(Vector3 target)
    {
        //TODO: something
    }
}