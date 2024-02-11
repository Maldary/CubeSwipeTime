using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowChecker : MonoBehaviour
{
    public Queue<Vector2> PressedArrowList => _arrowPressed;
    
    
    private Queue<Vector2> _arrowPressed = new Queue<Vector2>();

    public void Cleanup()
    {
        _arrowPressed.Clear();
    }
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Debug.Log("Влево");
            _arrowPressed.Enqueue(new Vector2(-1, 0));
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Debug.Log("Вправо");
            _arrowPressed.Enqueue(new Vector2(1, 0));
        }
        
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            _arrowPressed.Enqueue(new Vector2(0, -1));
            Debug.Log("Вверх");
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Debug.Log("Вниз)");
            _arrowPressed.Enqueue(new Vector2(0, 1)); 
        }
        
    }
}