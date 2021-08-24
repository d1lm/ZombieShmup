using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // we need this because we are working with an UI


   /* In order to implement a health bar for the player, we refereed to this video: https://www.youtube.com/watch?v=NE5cAlCRgzo&ab_channel=WayraCodes 
      by the YouTuber "Wayra Codes" which went over health bar creation in Unity */


public class HealthBar : MonoBehaviour
{
    private Image healthBar; //used to references the image of the health bar.
    public float currentHealth; //The current health.
    private float maxHealth = 100f; //Max health of the player.
    PlayerHealth Player; //used to reference the script that stores the players health. 

    private void Start() //private because we never want to change this unless player takes damage.
    {
        //We have too look for the health bar image and the health of the player (script)
        healthBar = GetComponent<Image>();
        Player = FindObjectOfType<PlayerHealth>();
    }

    private void Update()
    {
        currentHealth = Player.health; //continiously looks for the current health from the script. 
        healthBar.fillAmount = currentHealth / maxHealth; //math
    }

}
