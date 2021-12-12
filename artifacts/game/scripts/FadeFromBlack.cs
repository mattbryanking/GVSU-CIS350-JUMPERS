using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeFromBlack : MonoBehaviour
{
    float alphaLevel = 1f;

    void Start()
    {
        StartCoroutine(Delay());
    }

    // fades black image at start of intro sequence, easier than animating it
    IEnumerator Delay()
    {
        // time until appropriate for black image to fade
        yield return new WaitForSeconds(1.5f);
        
        while (true) 
        {
            // creates lower opacity based on time passed
            if (alphaLevel > 0) {
                alphaLevel -= (Time.deltaTime/4);
            } 
            
            // updates alpha level of black image
            GetComponent<SpriteRenderer>().color = new Color (0,0,0,alphaLevel);
            yield return null;
        }
    }
}
