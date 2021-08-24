using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //manages scene.

// Script to manage the player's health and deal damage to the player

public class PlayerHealth : MonoBehaviour
{

    

    static public PlayerHealth S;

    GameStateManager UpdateHighScore; //pulls script

    //bool deathFlag = false;

    public float health = 100f; //Player health
    public float enemyBulletDamage = 10f; //Enemy bullet damage



    public void OnTriggerEnter(Collider other)
    {


        GameObject otherGO = other.gameObject; //Code from the Space Shmup Game. Gets the object of the collider that was hit by the collision


        if (other.gameObject.tag == "EnemyBullet")
        {
            DamageSFX.Instance.PlayDamageSFX();
            health = health - enemyBulletDamage; //Hunter takes damage
            Destroy(otherGO); //Destroys the bullet. This code also comees from the Space Shmup game.


            if (health <= 0)
            {
                
            
                Destroy(transform.parent.gameObject); //Destroys the parent (Hunter)

                GameStateManager.Instance.UpdateHighScore();

                // Reset the score instance within the HighScoreManager Singleton after player dies and game ends
                HighScoreManager.Instance.ResetScore();

                //deathFlag = true;

                //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //gets next scene (gameover scene)

                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

            }
        }

    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }



}
