using UnityEngine;
using UnityEngine.UI;

public class JumpPowerup : MonoBehaviour
{
    public float increase = 8f;

    [SerializeField] private Text jumpText;
    [SerializeField] private Text jumpTextShadow;
    public AudioSource powerupSound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //checks if player triggered item
        if (collision.CompareTag("Player"))
        {
            //gets player object
            GameObject PlayerMovement = collision.gameObject;
            PlayerMovement playerScript = PlayerMovement.GetComponent<PlayerMovement>();


            if (playerScript)
            {
                //plays sound, changes jumpForce, destroys game object, updates text boxes
                powerupSound.Play();
                playerScript.jumpForce += increase;
                Destroy(gameObject);
                jumpText.text = "Jump: " + (playerScript.jumpForce - 20);
                jumpTextShadow.text = "Jump: " + (playerScript.jumpForce - 20);
            }
        }
    }
}
