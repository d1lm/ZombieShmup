using UnityEngine;
using UnityEngine.AI; // We need this since we are using the NavMeshAgent

/* In order to implement the enemy AI functionality, we needed to reference another tutorial given the complex nature of getting that AI to work
 * We followed the tutorial created by the YouTuber "Dave / GameDevelopment" available at this link: https://www.youtube.com/watch?v=UjkSFoLxesw&t=183s&ab_channel=Dave%2FGameDevelopment
 * We studied his code in order to fully understand it before we implemented it ourselves so that we could modify it as needed */

public class Enemy : MonoBehaviour
{
    public NavMeshAgent agent; //Gets the reference to our agent

    public Transform player; //Gets the reference to our player's transform

    public LayerMask whatIsGround, whatIsPlayer; //Reference to layer masks for what is the ground and player

    public float health;  //Setting the enemy health

    //Patroling
    public Vector3 walkPoint; //Creating a vector 3 as a walkpoint
    bool walkPointSet; //Check if walkpoint is set
    public float walkPointRange; //Setting the range of the walkpoint

    //Note that chasing does not need any variables

    //Attacking
    public float timeBetweenAttacks; //Setting time between attacks
    bool alreadyAttacked; //Determining if already attacked
    public GameObject projectile; //This is for allowing the enemy to shoot a projectile

    //States
    public float sightRange, attackRange; //Setting the sight and attack range
    public bool playerInSightRange, playerInAttackRange; //Checking if the player is within the sight and attack range

    private void Awake()
    {
        player = GameObject.Find("Hunter").transform; //Search for our player
        agent = GetComponent<NavMeshAgent>(); //Assign the NavMeshAgent
    }
    
    private void Update()
    {
        //Checking if player is within sight and attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        //Determining what state the enemy should be in
        if (!playerInSightRange && !playerInAttackRange) Patroling();
        if (playerInSightRange && !playerInAttackRange) ChasePlayer();
        if (playerInAttackRange && playerInSightRange) AttackPlayer();
    }

    private void Patroling()
    {
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
            agent.SetDestination(walkPoint); //Instructing the AI to go towards walkpoint

        //Calculating the distance to the walkpoint
        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //Checking if walkpoint was reached
        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false; //If the distance is less than 1, set walkpoint to false so that a new walkpoint can be set
    }
    private void SearchWalkPoint()
    {
        //Calculating a random walkpoint within a specified range
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        //Check to see if the random walkpoint is on the ground and within the map
        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true; //If it is within the map on the ground
    }

    private void ChasePlayer()
    {
        agent.SetDestination(player.position); //Instructing the AI to move towards the player position
    }

    private void AttackPlayer()
    {
        //Make sure enemy doesn't move
        agent.SetDestination(transform.position);

        transform.LookAt(player); //Ensure that enemy is looking at player before attacking

        if (!alreadyAttacked) //Checking if enemy has not already attacked
        {
            //This allows for the enemy to attack via projectiles
            //Attack code start
            Rigidbody rb = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();  //Creating projectile to be fired with a reference to its rigidbody
            rb.AddForce(transform.forward * 32f, ForceMode.Impulse);  //Applying an impulse force to rigidbody to move projectile forward
            rb.AddForce(transform.up * 8f, ForceMode.Impulse); //Applying an impulse force to rigidbody to move projectile upward (cause it to arc)
            //Attack code end

            alreadyAttacked = true; //Update state of alreadyAttacked to true
            Invoke(nameof(ResetAttack), timeBetweenAttacks); //Reset the attack
        }
    }

    //Method to reset the enemy attack
    private void ResetAttack()
    {
        alreadyAttacked = false; //Updating the state of alreadyAttacked to false to enable another attack
    }

    //This method allows the player to deal damage to the enemies
    public void TakeDamage(int damage)
    {
        health -= damage; //Subtract damage from the enemy total health amount

        if (health <= 0) Invoke(nameof(DestroyEnemy), 0.5f); //If enemy health drops to zero or below, the enemy is destroyed after 0.5 seconds
    }

    //Method to destroy the enemy
    private void DestroyEnemy()
    {
        Destroy(gameObject);
    }

    //Method that can be used to visualize the attack and sight range in the Unity Editor via Gizmos
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }
}