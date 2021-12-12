using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressSpace : MonoBehaviour
{
    public Animator anim;
    bool timerReached;
    float timer;
    public AudioSource sound;
    
    void Start()
    {
        anim = GetComponent<Animator>();
        timerReached = false;
        timer = 0;
    }

    
    void Update()
    {
        
        // timer waits until intro sequence is over and "press space" is presented to user
        if (!timerReached) {
            timer += Time.deltaTime;
        }

        // fades out "press space" after presented if space is pressed
        if (Input.GetKeyDown(KeyCode.Space) && !timerReached && timer > 18) {
            anim.Play("FadeOutUI");
            sound.Play();
            timerReached = true;
        }
    }

    
}
