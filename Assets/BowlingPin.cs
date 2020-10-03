using System.Collections;
using UnityEngine;

/// <summary> Class to determine when the bowling pins should collapse and the score should be updated <summary> 
public class BowlingPin : MonoBehaviour
{
    public Score score;

    public ParticleSystem particleExplosion;

    private int pinCount = 0;

    /// <summary> Enumerator to create the particle explosion <summary> 
    IEnumerator ExampleCoroutine()
    {
         particleExplosion.Play();
        yield return new WaitForSeconds(1);
        particleExplosion.Stop();
        score.AddScore();
        this.gameObject.SetActive(false);
        }

    void Update()
    {
        if (this.gameObject.transform.up.y < .6f)
        {
            pinCount += 1;

        }

        if (pinCount == 10)
        {
            StartCoroutine(ExampleCoroutine());
        }

        if (Input.GetKeyUp(KeyCode.B))
        {
            pinCount = 0;
        }
    }
}
