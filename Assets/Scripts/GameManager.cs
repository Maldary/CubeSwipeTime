using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int levelsCount;
    private TextMeshProUGUI levelsText;
    void Start()
    {
        levelsText = GetComponent<TextMeshProUGUI>();
        levelsCount = PlayerPrefs.GetInt("Levels complete", 0);
        levelsText.text = levelsCount.ToString();
    }
    
    public void AddLevelsToCount(int amount)
    {
        levelsCount += amount;
        Debug.Log("+1 count");
        levelsText.text = levelsCount.ToString();
        PlayerPrefs.SetInt("Levels complete", levelsCount);
    }

    public void RefreshLevelsCount()
    {
        levelsCount = 0;
    }

}
