using UnityEngine;
using UnityEngine.UI;

public class Speed_Powerup : MonoBehaviour {
    public float increase = 5f;

    [SerializeField] private Text speedText;
    [SerializeField] private Text speedTextShadow;
    public AudioSource powerupSound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //checks that it was the player who triggered item
        if (collision.CompareTag("Player"))
        {
            //gets player object
            GameObject PlayerMovement = collision.gameObject;
            PlayerMovement playerScript = PlayerMovement.GetComponent<PlayerMovement>();

            if (playerScript)
            {
                //plays powerup sound, changes movement speed, destroys game object, and changes text display
                powerupSound.Play();
                playerScript.moveSpeed += increase;
                Destroy(gameObject);
                speedText.text = "Speed: " + (playerScript.moveSpeed - 7);
                speedTextShadow.text = "Speed: " + (playerScript.moveSpeed - 7);
            }
        }
    }
}
