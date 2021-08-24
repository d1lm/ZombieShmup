using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieDeathSound : MonoBehaviour
{
    private static ZombieDeathSound instance;

    public static ZombieDeathSound Instance
    {
        get
        {
            return instance;
        }
    }

    private AudioSource zombieDeathSource;

    private void Awake()
    {
        instance = this;

        zombieDeathSource = this.gameObject.GetComponent<AudioSource>();

        DontDestroyOnLoad(this.gameObject);
    }

    public void PlayZombieDeath()
    {
        zombieDeathSource.PlayOneShot(zombieDeathSource.clip);
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
