using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class coinCollector : MonoBehaviour
{
    private int coins = 0;

    [SerializeField] private Text coinText;
    [SerializeField] private Text coinTextShadow;

    public AudioSource coinSound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // checks if object contacted is a coin
        if (collision.gameObject.CompareTag("coin"))
        {
            // removes coin from game, plays sound effect
            Destroy(collision.gameObject);
            coinSound.Play();

            // increases coin counter and updates hud
            coins++;
            coinText.text = "Coins: " + coins;
            coinTextShadow.text = "Coins: " + coins;
        }
    }
}
