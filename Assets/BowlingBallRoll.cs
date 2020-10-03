using System;
using System.Collections;
using UnityEngine;

/// <summary> Class to control the users control and subsequent movement of the bowling ball <summary> 
public class BowlingBallRoll : MonoBehaviour
{
    public EventHandler eventHandler;

    public Transform firePoint;

    public Score score;

    public float speed = 20f;

    private Rigidbody ballRigidBody;

    public Swipe swipe; 

   private bool turnComplete;

    private float holdDownTime;
    private float holdDownStartTime = 0f;
    void Start()
    {
        ballRigidBody = this.GetComponent<Rigidbody>();
        eventHandler += OnClickPress;
    }

      private void OnClickPress(object sender, EventArgs e)
      {
          if (turnComplete == false)
          { 
              ballRigidBody.AddForce(firePoint.forward * (holdDownTime * 300) *
                                   (25)); // must be a way to use current ball
            ballRigidBody.freezeRotation = true;
            
          score.DisplayScore();

            
            turnComplete = true;
          }
          swipe.gameObject.SetActive(true);
       }

    /// <summary> Frame by frame to identify if the user wishes to reset, navigate and power bowling ball <summary> 
    void Update()
    {
       if (Input.GetKeyUp(KeyCode.B))
       {
            ballRigidBody.position = firePoint.position;
            ballRigidBody.rotation = firePoint.rotation;

            turnComplete = false;
       }

        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            GetComponent<Rigidbody>().AddForce(new Vector3(1, 0, 0), ForceMode.Impulse);
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            GetComponent<Rigidbody>().AddForce(new Vector3(-1, 0, 0), ForceMode.Impulse);
        }
        this.transform.Translate(Input.GetAxis("Horizontal"), 0, 0);

        if (Input.GetMouseButtonDown(0))
        {
            holdDownStartTime = Time.time;
         
        }

        if (Input.GetMouseButtonUp(0))
        {
            StartCoroutine(score.UserLoss());
            PowerBall();
           
        }
        
    }
    
    /// <summary> method to power the bowling ball based on the user hold time <summary> 
    private void PowerBall()
    {       
      
            holdDownTime = Time.time - holdDownStartTime;

            if (holdDownTime > 0f && holdDownTime < 3f)
            {
                eventHandler?.Invoke(this, EventArgs.Empty);
            }
            else if (holdDownTime >= 3f)
            {
                holdDownTime = 3f;
                eventHandler?.Invoke(this, EventArgs.Empty);
            }

        
    }

}
