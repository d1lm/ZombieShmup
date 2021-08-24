using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPU : MonoBehaviour
{
    public float timer = 5.0f; //a timer 

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, timer); //destroys the gameObject depending on the time. 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
