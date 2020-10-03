using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
   public int scoreCount = 0;

   public static bool IsOver;
    
   void Update()
    {
        if (Input.GetKeyUp(KeyCode.B))

        {
            ChangeText();
            scoreCount = 0;
        }
    }

    public void AddScore()
    {
       scoreCount += 1;
       DisplayScore();
    }
    public void ChangeText()
    {
        this.GetComponent<Text>().text = "";
    }
    public void DisplayScore()
    {
        this.GetComponent<Text>().text = "Your score is: " + scoreCount + ", press B to restart";
    }

    public void UserNoPinConnection()
    {
        this.GetComponent<Text>().text = "Unfortunately you hit 0 pins, press B to restart";
    }
}
