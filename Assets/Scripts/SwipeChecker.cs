using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeChecker : MonoBehaviour
{
    private Vector2 fingerDown;
    private Vector2 fingerUp;
    public float swipeThreshold = 20f;

    void Update() 
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            fingerDown = Input.GetTouch(0).position;
            fingerUp = Input.GetTouch(0).position;
        }
        
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            fingerUp = Input.GetTouch(0).position;
            CheckSwipe();
        }
    }
    void CheckSwipe()
    {
        if (Mathf.Abs(fingerDown.x - fingerUp.x) > swipeThreshold)
        {
            if (fingerDown.x < fingerUp.x)
            {
                Debug.Log("Swipe right");
            }
            else if (fingerDown.x > fingerUp.x)
            {
                Debug.Log("Swipe left");
            }
        }

        if (Mathf.Abs(fingerDown.y - fingerUp.y) > swipeThreshold)
        {
            if (fingerDown.y < fingerUp.y)
            {
                Debug.Log("Swipe up");
            }
            else if (fingerDown.y > fingerUp.y)
            {
                Debug.Log("Swipe down");
            }
        }

        fingerUp = fingerDown;
    }
}
