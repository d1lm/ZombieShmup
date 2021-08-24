using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health = 100f; //health
    public float BulletDamage = 0.1f; //Hunters bullet damage


    public void OnTriggerEnter(Collider other)
    {
        GameObject otherGO = other.gameObject; //Code from the Space Shmup Game. Gets the object of the collider that was hit by the collision


        if (other.gameObject.tag == "Bullet")
        {
            health = health - BulletDamage; //Enemy takes damage
            //Destroy(otherGO); //Destroys the bullet. This code also comes from the Space Shmup game.


            if (health <= 0)
            {

                ZombieDeathSound.Instance.PlayZombieDeath();
                Destroy(transform.parent.gameObject); //Destroys the parent (Enemy)
                HighScoreManager.Instance.AddScore(); //Accumulates the player score
               


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
