using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSFX : MonoBehaviour
{
    private static DamageSFX instance;

    public static DamageSFX Instance
    {
        get
        {
            return instance;
        }
    }

    private AudioSource DamageSFXSource;

    private void Awake()
    {
        instance = this;

        DamageSFXSource = this.gameObject.GetComponent<AudioSource>();

        DontDestroyOnLoad(this.gameObject);
    }

    public void PlayDamageSFX()
    {
        DamageSFXSource.PlayOneShot(DamageSFXSource.clip);
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
