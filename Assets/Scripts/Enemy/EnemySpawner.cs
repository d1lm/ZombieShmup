using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    //bool flag = false;

    public Transform[] SpawnPoints; //Spawn Point Arrays.
    public float timer = 1.0f;
    public Transform player;


    //public GameObject PowerUps; 
    public GameObject[] Enemies; //we can store multiple Enemies within this array.

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemies", timer, timer);      //invokeRepeating(string methodname, float time, float repeat rate). repeats the function with the time depending on the timer. 
    }

    // Update is called once per frame
    void Update()
    {
        
        if(player == null)
        {
            CancelInvoke();
        }


    }

    void SpawnEnemies()
    {
        player = GameObject.Find("Hunter").transform;

        //int spawnIndex2 = 0;

        int spawnIndex = Random.Range(0, SpawnPoints.Length); //Stores one of the random spawn point

        //while (spawnIndex == spawnIndex2) //does not matter where the enemie spawns as long as they spawn. 
        //{
        //    spawnIndex = Random.Range(0, SpawnPoints.Length);
        //}

        int objectIndex = Random.Range(0, Enemies.Length); //stores one of the random power ups

        Instantiate(Enemies[objectIndex], SpawnPoints[spawnIndex].position, SpawnPoints[spawnIndex].rotation); //spawns the PowerUp in a random spawn point

       // spawnIndex2 = spawnIndex; //this is to ensure that the power ups do not overlap.


    }


}
