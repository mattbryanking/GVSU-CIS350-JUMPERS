using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelComplete : MonoBehaviour
{
    private AudioSource finishSound;
    private void Start()
    {
        //gets audio for completing level
        finishSound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //checks if triggered by player
        if (collision.gameObject.CompareTag("Player"))
        {
            //plays audio, after 2 seconds invokes CompleteLevel()
            finishSound.Play();
            Invoke("CompleteLevel", 2f);
        }
    }

    private void CompleteLevel()
    {
        //loads next level
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
