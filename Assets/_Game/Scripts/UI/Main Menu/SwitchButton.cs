using UnityEngine;

public class SwitchButton : MonoBehaviour
{ 
    public GameObject[] levels; 
    private int index;
    
    void Start() 
    { 
        index = PlayerPrefs.GetInt("index", 0); 
        SetActiveLevel();
    } 
    
    public void Next() 
    { 
        index++; 
        if (index >= levels.Length) index = 0; 
        SetActiveLevel(); 
    } 

    public void Previous() 
    { 
        index--; 
        if (index < 0) 
        index = levels.Length - 1; 
        SetActiveLevel(); 
    } 
    
    void SetActiveLevel() 
    { 
        for (int i = 0; i < levels.Length; i++) 
        { 
            levels[i].SetActive(i == index); 
        } 
    
        PlayerPrefs.SetInt("index", index); 
        PlayerPrefs.Save(); 
    } 
}