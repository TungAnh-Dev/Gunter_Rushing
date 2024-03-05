using UnityEngine;

public class LookAtTarget : MonoBehaviour
{
    void Start()
    {
        transform.LookAt(LevelManager.Instance.Player.TF);
    }
}