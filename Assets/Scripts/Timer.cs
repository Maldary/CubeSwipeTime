using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public PlayerController playerController;
    public float initialTime = 7f;
    private float currentTime;
    public GridMaze gridMaze; 
    public TextMeshProUGUI timerDisplay;
  
    void Start()
    {
        currentTime = initialTime;
        UpdateTimerDisplay();
        StartCoroutine(DecreaseTimer());
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
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            currentTime -= 0.1f;
            UpdateTimerDisplay();

            if (currentTime <= 0f)
            {
                UpdateTimerOO();
                playerController.StartMove();
                if (gridMaze.IsMazePassed())
                {
                    UpdateTimer();
                }
                yield return new WaitForSeconds(playerController.stepCounts*0.4f);
                UpdateTimerDisplay();
            }
        }
    }
          public void UpdateTimer()
           {
               initialTime -= 0.3f;
           }

}

 

