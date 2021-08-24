using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunFire : MonoBehaviour
{
    private static GunFire instance;

    public static GunFire Instance
    {
        get
        {
            return instance;
        }
    }

    private AudioSource GunFireSource;

    private void Awake()
    {
        instance = this;

        GunFireSource = this.gameObject.GetComponent<AudioSource>();

        DontDestroyOnLoad(this.gameObject);
    }

    public void PlayGunFire()
    {
        GunFireSource.loop = true;
        GunFireSource.Play();
    }

    public void StopGunFire()
    {
        GunFireSource.loop = false;
        GunFireSource.Stop();
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
