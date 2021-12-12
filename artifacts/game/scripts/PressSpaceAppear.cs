using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressSpaceAppear : MonoBehaviour
{
    public Animator anim;
    public bool timerReached;
    float timer;

    void Start()
    {
        anim = GetComponent<Animator>();
        timerReached = false;
        timer = 0;
    }

    // waits until user input is accepted in intro sequence
    void Update()
    {
        if (!timerReached) {
            timer += Time.deltaTime;
        }

        // starts coroutine after space is pressed
        if (Input.GetKeyDown(KeyCode.Space) && !timerReached && timer > 18) {
            StartCoroutine(Delay());
        }
    }

    // fades in start menu after press space fades out
    IEnumerator Delay() {
        yield return new WaitForSeconds(1.5f);
        anim.Play("FadeInUI");
        timerReached = true;
    }
}
