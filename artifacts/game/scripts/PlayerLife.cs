using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    //Defines all variables
    private Rigidbody2D rb;
    private Animator anim;
    public BoxCollider2D coll;
    public AudioSource deathSound;
    private void Start()
    {
        //Accessing other parts of the player
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        coll = GetComponent<BoxCollider2D>();
    }

    //Checks for collision with any object tagged "kill"
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Kill"))
        {
            Die();
        }
    }
    //Death animation, sound, and reset
    private void Die()
    {
        rb.bodyType = RigidbodyType2D.Static;
        coll.isTrigger = true;
        deathSound.Play();
        anim.SetTrigger("death");
        Invoke("RestartLevel",0.43f);
    }

    //Restarts level
    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    //Can reset level by pressing 'R'
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Die();
        }
    }
}
