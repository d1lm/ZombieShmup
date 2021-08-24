using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/* In order to spawn in our powerups, we referred to this video: https://www.youtube.com/watch?v=iLTP4EbM1N4&list=PLAeIzH0X_Fobg-uYDydKygpqHjMfPm23Z&index=758&ab_channel=xOctoManx
 * which was created by the YouTuber "xOctoManx" which is a Unity tutorial that goes over how to spawn random objects at random positions */


public class CreatePU : MonoBehaviour
{

    public Transform[] SpawnPoints; //Spawn Point Arrays.
    public float timer = 5.0f;

    

    //public GameObject PowerUps; 
    public GameObject[] PowerUps; //we can store multiple PowerUps within this array. 
    


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnPowerUps", timer, timer);      //invokeRepeating(string methodname, float time, float repeat rate). repeats the function with the time depending on the timer. 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnPowerUps()
    {
        int spawnIndex2 = 0;

        int spawnIndex = Random.Range(0,SpawnPoints.Length); //Stores one of the random spawn point

        while(spawnIndex == spawnIndex2) //if the spawnindex is equal to the previous spawn index we run the random generator again.
        {
            spawnIndex = Random.Range(0, SpawnPoints.Length);
        }

        int objectIndex = Random.Range(0, PowerUps.Length); //stores one of the random power ups

        Instantiate(PowerUps[objectIndex], SpawnPoints[spawnIndex].position, SpawnPoints[spawnIndex].rotation); //spawns the PowerUp in a random spawn point

        spawnIndex2 = spawnIndex; //this is to ensure that the power ups do not overlap.


    }
}
