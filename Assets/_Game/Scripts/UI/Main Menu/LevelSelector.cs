using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{
    [SerializeField] int level;
    [SerializeField] TextMeshProUGUI levelText;
    [SerializeField] Button levelBtn;
    [SerializeField] UI_MainMenu mainMenu;

    void Start()
    {
        levelText.SetText(level.ToString());
        levelBtn.onClick.AddListener(() => mainMenu.LoadLevel(level-1));
    }

}