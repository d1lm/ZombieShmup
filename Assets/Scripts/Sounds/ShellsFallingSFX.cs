using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellsFallingSFX : MonoBehaviour
{
    private static ShellsFallingSFX instance;

    public static ShellsFallingSFX Instance
    {
        get
        {
            return instance;
        }
    }

    private AudioSource ShellsFallingSFXSource;

    private void Awake()
    {
        instance = this;

        ShellsFallingSFXSource = this.gameObject.GetComponent<AudioSource>();

        DontDestroyOnLoad(this.gameObject);
    }

    public void PlayShellsFallingSFX()
    {
        ShellsFallingSFXSource.PlayOneShot(ShellsFallingSFXSource.clip);
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
