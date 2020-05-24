using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundManager : MonoBehaviour
{
    public static AudioClip FireSound, explodeSound, switchSound;
    static AudioSource Mysource;
    // Start is called before the first frame update
    void Start()
    {

        FireSound = Resources.Load<AudioClip>("Shot_01");
        explodeSound = Resources.Load<AudioClip>("PowUp_01");

        Mysource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "Shot_01" :
                Mysource.PlayOneShot(FireSound);
                break;

            case "PowUp_01":
                Mysource.PlayOneShot(explodeSound);
                break;

        }

       


    }
}
