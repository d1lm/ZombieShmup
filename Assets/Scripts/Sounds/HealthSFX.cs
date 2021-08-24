using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSFX : MonoBehaviour
{
    private static HealthSFX instance;

    public static HealthSFX Instance
    {
        get
        {
            return instance;
        }
    }

    private AudioSource HealthSFXSource;

    private void Awake()
    {
        instance = this;

        HealthSFXSource = this.gameObject.GetComponent<AudioSource>();

        DontDestroyOnLoad(this.gameObject);
    }

    public void PlayHealthSFX()
    {
        HealthSFXSource.PlayOneShot(HealthSFXSource.clip);
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

