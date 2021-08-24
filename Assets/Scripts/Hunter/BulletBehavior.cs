using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* In order to implement the gun and it's basic behavior, we again referenced another tutorial video by the YouTuber "gamesplusjames"
 * Specifically, we referenced the second video in his series titled "Unity Top Down Shooter #2 - Guns"
 * which can be found at this link: https://www.youtube.com/watch?v=JVibUZugFAQ&ab_channel=gamesplusjames
 * We followed his guide, and made sure that we understood everything that the code did. */

public class BulletBehavior : MonoBehaviour
{

    public float velocity; //Public variable for projectile speed

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Instructing the projectile to move forward out of the gun at the designated velocity independent of framerate
        transform.Translate(Vector3.forward * velocity * Time.deltaTime);

        Destroy(gameObject, 2); //Destroying the instance of the projectile after 2 seconds to conserve memory
    }
}
