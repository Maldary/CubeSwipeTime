using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public PlayerController playerController;
    public float initialTime = 6f;
    private float currentTime;
    [SerializeField]
    private float lvlWinTimeDeacreser;
    public GridMaze gridMaze; 
    public TextMeshProUGUI timerDisplay;
  
    void Start()
    {
        currentTime = initialTime - PlayerPrefs.GetInt("isPreviusLevelWon", 0) * lvlWinTimeDeacreser;
        UpdateTimerDisplay();
        StartCoroutine(DecreaseTimer());
    }

    private void OnDestroy()
    {
        StopAllCoroutines();
    }

    void UpdateTimerDisplay()
        {
            int seconds = Mathf.FloorToInt(currentTime);
            int milliseconds = Mathf.FloorToInt((currentTime - seconds) * 100);
            timerDisplay.text = string.Format("{0:d2}:{1:d2}", seconds, milliseconds);
        }
        private void UpdateTimerOO() 
        {
            if (currentTime <= 0f)
            {
                timerDisplay.text = "00:00";
            }
        }

    IEnumerator DecreaseTimer()
    {
        Debug.Log(currentTime);
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            currentTime -= 0.1f;
            UpdateTimerDisplay();

            if (currentTime <= 0f)
            {
                UpdateTimerOO();
                playerController.StartMove();
             
                yield return new WaitForSeconds(playerController.stepCounts*0.4f);
                UpdateTimerDisplay();
            }
        }
    }
}

 

