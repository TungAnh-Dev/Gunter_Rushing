using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    public Transform TF;
    [SerializeField] Vector3 offset;
    [SerializeField] float maxLeftLimit = -5f; // Giới hạn tối thiểu bên trái
    [SerializeField] float maxRightLimit = 5f; // Giới hạn tối đa bên phải


    private void LateUpdate()
    {
        if(!GameManager.Instance.IsState(GameState.GamePlay)) return;

        Vector3 targetPosition = LevelManager.Instance.CurrentPlayer.TF.position + offset;
        targetPosition.x = Mathf.Clamp(targetPosition.x, maxLeftLimit, maxRightLimit);

        TF.position = Vector3.Lerp(TF.position, targetPosition, Time.deltaTime * 5f);
    }
}
