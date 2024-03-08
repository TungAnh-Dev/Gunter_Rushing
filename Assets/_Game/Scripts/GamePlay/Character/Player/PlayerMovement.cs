using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] PlayerData playerData;

    float moveSpeed;
    Anim anim;
    void Start()
    {
        anim = GetComponent<Anim>();
        moveSpeed = playerData.MoveSpeed;
    }

    void Update()
    {
        if(!GameManager.Instance.IsState(GameState.GamePlay)) return;
        
        transform.position = JoystickControl.direct * moveSpeed * Time.deltaTime + transform.position;

        if (JoystickControl.direct != Vector3.zero)
        {
            transform.forward = JoystickControl.direct;
            anim.ChangeAnim(Constants.ANIM_RUN);
        }
        else
        {
            anim.ChangeAnim(Constants.ANIM_IDLE);
        }
    }
}