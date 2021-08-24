using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedSFX : MonoBehaviour
{
    private static SpeedSFX instance;

    public static SpeedSFX Instance
    {
        get
        {
            return instance;
        }
    }

    private AudioSource SpeedSFXSource;

    private void Awake()
    {
        instance = this;

        SpeedSFXSource = this.gameObject.GetComponent<AudioSource>();

        DontDestroyOnLoad(this.gameObject);
    }

    public void PlaySpeedSFX()
    {
        SpeedSFXSource.PlayOneShot(SpeedSFXSource.clip);
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
