
using UnityEngine;
using UnityEngine.UI;

public class LevelSelectMenu : MonoBehaviour
{
    int levelsUnlocked;
    [SerializeField] Button[] lvBtn;

    public void Setup()
    {
        levelsUnlocked = PlayerPrefs.GetInt(Constants.LevelsUnlocked);

        for (int i = 0; i < lvBtn.Length; i++)
        {
            if(i > levelsUnlocked)
                lvBtn[i].interactable = false;
            else
                lvBtn[i].interactable = true;
        }

    }

    public void ActiveLevelSelectMenu()
    {
        gameObject.SetActive(true);
    }

    public void InactiveLevelSelectMenu()
    {
        gameObject.SetActive(false);
    }
}
