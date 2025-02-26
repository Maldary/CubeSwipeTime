using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    
    private GameObject _gameObject;
    private GameObject plusPrefab;
    private const int DistanceDifferent = 4;
    public ArrowChecker arrowChecker;
    public GridMaze gridMaze;
    private Vector2 _currentPosition;
    public int stepCounts;
    public Timer timer;
    public AudioClip PlusSound;
    public AudioClip CollisionSound;
    [SerializeField]
    private GameManager _gameManager;
    private int levelValue = 1;
    // public WinLoseText winLoseText;
    public TextMeshPro WinLoseDetect;
    private void Awake()
    {
        DOTween.defaultAutoPlay = AutoPlay.None;
        WinLoseDetect = GetComponent<TextMeshPro>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Plus"))
        {
            AudioSource.PlayClipAtPoint(PlusSound, transform.position);
            Destroy(other.gameObject);
            Debug.Log("sound");
        }
    }

    public void StartMove()
    {
        DOTween.defaultAutoPlay = AutoPlay.None;
        
        Sequence sequence = DOTween.Sequence();

        Vector3 position = transform.position;

        bool isFirstRightPassed = false;

        for (int i = 0; i < arrowChecker.PressedArrowList.Count; i++)
        {
            var aVector2 = arrowChecker.PressedArrowList.ToArray()[i];
            
            int stepCount = gridMaze.GetStepsCount(aVector2);
            
            //Первый шаг только вправо
            if (aVector2 == Vector2.right && !isFirstRightPassed)
            {
                stepCount += DistanceDifferent;
                isFirstRightPassed = true;
                
            }
            if (gridMaze.IsMazePassed() && i == arrowChecker.PressedArrowList.Count - 1)
            {
                stepCount += DistanceDifferent;
                
            }
            stepCounts += stepCount;
            Debug.Log(stepCount);
            Debug.Log(stepCounts);
            position += new Vector3(aVector2.y, 0, aVector2.x) * stepCount;
            
            sequence.Append(transform.DOMove(position, 0.35f).SetEase(Ease.InCirc));
            sequence.Append(transform.DOShakeScale(0.05f, 1.35f, 15));
        }
        sequence.Play();
        WinLose(sequence);
        
    }
  
    // ReSharper disable Unity.PerformanceAnalysis
    public void WinLose(Sequence sequence)
    {
        sequence.AppendCallback(() =>
        {
            if (gridMaze.IsMazePassed())
            {
                StartCoroutine(FinishRoutine());
                _gameManager.AddLevelsToCount(levelValue);
                PlayerPrefs.SetInt("isPreviusLevelWon",  PlayerPrefs.GetInt("isPreviusLevelWon", 0)+1);
            }
            else
            {
                StartCoroutine(LooseRoutine());
                if (_gameManager.levelsCount > _gameManager.highScoreValue)
                {
                    _gameManager.SetHighScore();
                }
                _gameManager.RefreshLevelsCount();
                PlayerPrefs.SetInt("isPreviusLevelWon", 0);
            }
        });
    }

    private IEnumerator FinishRoutine()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
    private IEnumerator LooseRoutine()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
}