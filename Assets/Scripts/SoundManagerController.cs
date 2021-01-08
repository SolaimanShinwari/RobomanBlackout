using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerController : MonoBehaviour
{
    //Created Instance of SoundManagerController Class so that other classes can Access it
    public static SoundManagerController Instance=null;

    private void Awake()
    {
        //If multiple Instances of this class is created then Don't destroy this one and destroy others
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    //All references of AudioSource stored in these variables which can be directly accessed using Instance of this class
    public AudioSource clickSound;
    public AudioSource backgroundSound;
    public AudioSource bossSound;
    public AudioSource shootSound;
    public AudioSource explosionSound;
}
