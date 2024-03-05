
using UnityEditor.Timeline;
using UnityEngine;

public class Anim : MonoBehaviour
{
    [SerializeField] Animator anim;
    private string currentAnim;
    
    public void ChangeAnim(string animName)
    {
        if (currentAnim != animName)
        {
            anim.ResetTrigger(currentAnim);
            currentAnim = animName;
            anim.SetTrigger(currentAnim);
        }
    }

    public void ResetAnimAfterSecond(float second)
    {
        Invoke(nameof(ResetAnim), second);
    }

    public void ResetAnim()
    {
        currentAnim = "";
    }

}
