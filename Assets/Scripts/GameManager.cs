using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private const string LevelsCompleteKey = "Levels complete";
    private const string HighScoreKey = "HighScoreSet";
    public int levelsCount;
    public TextMeshProUGUI levelsText;
    public TextMeshProUGUI highScore;
    public int highScoreValue;
    void Start()
    {
        levelsText = GetComponent<TextMeshProUGUI>();
        levelsCount = PlayerPrefs.GetInt(LevelsCompleteKey, 0);
        levelsText.text = levelsCount.ToString();
        highScore = GetComponent<TextMeshProUGUI>();
    }
    
    public void AddLevelsToCount(int amount)
    {
        levelsCount += amount;
        Debug.Log("+1 count");
        levelsText.text = levelsCount.ToString();
        PlayerPrefs.SetInt(LevelsCompleteKey, levelsCount);
    }

    // public void SetHighScore()
    // {
    //     highScore.text = highScoreValue.ToString();
    //     PlayerPrefs.SetInt(HighScoreKey, highScoreValue);
    // }
        
    public void RefreshLevelsCount()
    {
        levelsCount = 0;
        PlayerPrefs.SetInt(LevelsCompleteKey, levelsCount);
    }
    
}
