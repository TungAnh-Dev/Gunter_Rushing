
using UnityEngine;

public class Player : Character
{
    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] PlayerInput playerInput;
    [SerializeField] PlayerAutoAttack playerAutoAttack;
    public Level level;
    Vector3 targetPoint;
    void Start()
    {
        playerInput.OnMove += () => Moving(TF ,playerInput.direction);
        playerInput.OnStop += () => StopMoving();
    }

    void Update()
    {
       OnAttack();
    }


    public override void OnInit()
    {
        base.OnInit();
        TF.position = LevelManager.Instance.StartPoint;
    }

    private void Moving(Transform TF,Vector3 direction)
    {
        playerMovement.OnMove(TF ,direction);
        anim.ChangeAnim(Constants.ANIM_RUN);
    }

    private void StopMoving()
    {
        anim.ChangeAnim(Constants.ANIM_IDLE);
    }

    public override void OnAttack()
    {
        target = GetTargetInRange();
        if(target != null)
        {
            targetPoint = target.TF.position;
            playerAutoAttack.OnAttack(targetPoint);
            //ChangeAnim(Constant.ANIM_ATTACK);
        }
    }

}
