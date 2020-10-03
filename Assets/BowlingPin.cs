using System.Collections;
using UnityEngine;

/// <summary> Class to determine when the bowling pins should collapse and the score should be updated <summary> 
public class BowlingPin : MonoBehaviour
{
    public Score score;

    public ParticleSystem particleExplosion;

    IEnumerator ExampleCoroutine()
    {
        particleExplosion.Play();
        yield return new WaitForSeconds(2);
        particleExplosion.Stop();
        score.AddScore();
        this.gameObject.SetActive(false);
        }

    void Update()
    {
        if (this.gameObject.transform.up.y < .6f)
        {
           
          
            StartCoroutine(ExampleCoroutine());
           

            //score.AddScore();
            
        }

    }

}
