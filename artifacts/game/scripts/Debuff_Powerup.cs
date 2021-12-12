using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Debuff_Powerup : MonoBehaviour
{
    private int debuffs = 0;

    [SerializeField] private Text debuffText;
    [SerializeField] private Text debuffTextShadow;
    [SerializeField] private Text jumpText;
    [SerializeField] private Text jumpTextShadow;
    [SerializeField] private Text speedText;
    [SerializeField] private Text speedTextShadow;

    public AudioSource debuffSound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // checks if object contacted is a debuff
        if (collision.gameObject.CompareTag("debuff"))
        {
            // removes debuff from game
            Destroy(collision.gameObject);
            
            // increases debuff counter and updates hud
            debuffs++;
            debuffText.text = "Debuffs: " + debuffs;
            debuffTextShadow.text = "Debuffs: " + debuffs;
        }
    }

    private void Update() {
        
        // press E to use debuff
        if(Input.GetKeyDown(KeyCode.E) && debuffs > 0) {

            // removes debuff from "inventory"
            debuffs--;
            GameObject PlayerMovement = GameObject.FindGameObjectWithTag("Player");
            PlayerMovement playerScript = PlayerMovement.GetComponent<PlayerMovement>();

            // plays sound
            debuffSound.Play();

            // resets jump height and move speed
            if (playerScript)
            {
                playerScript.jumpForce = 14f;
                playerScript.moveSpeed = 7f;
            }

            // updates hud
            debuffText.text = "Debuffs: 0";
            debuffTextShadow.text = "Debuffs: 0";
            jumpText.text = "Jump: 0";
            jumpTextShadow.text = "Jump: 0";
            speedText.text = "Speed: 0";
            speedTextShadow.text = "Speed: 0";
        }
    }
}
