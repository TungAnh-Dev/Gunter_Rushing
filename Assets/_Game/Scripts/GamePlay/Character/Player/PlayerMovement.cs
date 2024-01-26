using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    public void OnMove(Transform TF,Vector3 direction)
    {
        TF.position = direction * moveSpeed * Time.deltaTime + TF.position;

        if (direction != Vector3.zero)
        {
            TF.forward = direction;
        }
    }
}