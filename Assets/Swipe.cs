using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary> Class exec <summary> 
public class Swipe : MonoBehaviour
{
    private Vector2 fingerDown;
    private Vector2 fingerUp;
  
    private Vector3 mouseDown = new Vector3();
    private Vector3 mouseStart = new Vector3();

    void LateUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mouseStart = Input.mousePosition;
        }
        if (DragDrop.ISEnabled)
        {
            CheckPhoneSwipe();

            CheckMouseSwipe();
        }
    }

    private void CheckMouseSwipe()
    {
        if (Input.GetMouseButtonUp(0))
        {
            if (mouseStart.y > 700)
            {
                mouseDown = Input.mousePosition;
                checkSwipe(mouseStart, mouseDown);
            }
        }
    }
    
    private void CheckPhoneSwipe()
    {
        foreach (Touch touch in Input.touches) 
        {
            if (touch.phase == TouchPhase.Began)
            {
                fingerUp = touch.position;
                fingerDown = touch.position;
            }
            //Detects swipe after finger is released
            if (touch.phase == TouchPhase.Ended)
            {
                fingerDown = touch.position;
                checkSwipe(fingerUp, fingerDown);
            }
        }
    }

    void checkSwipe(Vector3 down, Vector3 up)
    {
        var f = down.x - up.x;
        if (down.x - up.x > 0) //Right swipe
        {
            SwitchScene();
        }
        else if (down.x - up.x < 0) //left swipe
        {
            SwitchScene();
        }
    }

    private void SwitchScene()
    {
        var scene = SceneManager.GetActiveScene();
        
        if (scene.name == "UIScene")
        {
            SceneManager.LoadScene("GameScene");
        }
        else
        {
            SceneManager.LoadScene("UIScene");
        }
    }
}

