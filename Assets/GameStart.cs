using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary> Class executed to record initial pin positions and display instructions <summary> 
public class GameStart : MonoBehaviour
{
    private List<Vector3> pinPositions;
    private Vector3 ballPosition;

    private List<Quaternion> pinRotations;

    private GameObject[] pins;

    public GameObject IntroMessage;

    void Start()
    {
       StartCoroutine(IntroMessageTimer());
        
        pins = GameObject.FindGameObjectsWithTag("Pin");
        pinPositions = new List<Vector3>();
        pinRotations = new List<Quaternion>();
     foreach (var pin in pins)
        {
            pinPositions.Add(pin.transform.position);
            pinRotations.Add(pin.transform.rotation);
        }

        ballPosition = GameObject.FindGameObjectWithTag("Ball").transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.B))
        {
            ResetGame();
        }
    }

    private void ResetGame()
    {
        var ball = GameObject.FindGameObjectWithTag("Ball");

        ball.GetComponent<Rigidbody>().velocity = Vector3.zero;
        ball.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        ball.transform.position = ballPosition;

        for (int i = 0; i < pins.Length; i++)
        {
            var pinPhysics = pins[i].GetComponent<Rigidbody>();
            pins[i].SetActive(true);
            pinPhysics.velocity = Vector3.zero;
            pinPhysics.position = pinPositions[i];
            pinPhysics.rotation = pinRotations[i];
            pinPhysics.velocity = Vector3.zero;
            pinPhysics.angularVelocity = Vector3.zero;
        }
    }

    IEnumerator IntroMessageTimer()
    {
        if (IntroMessage != null)
        {
            IntroMessage.SetActive(true);
            yield return new WaitForSeconds(7);
            if (IntroMessage != null)
            {
                IntroMessage.SetActive(false);
            }
        }
    }
}
