using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{

    public static AudioClip Schlag,hit;
    static AudioSource audioSrc;

    void Start()
    {
        Schlag = Resources.Load<AudioClip>("Schlag");
        hit = Resources.Load<AudioClip>("hit");

        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public static void PlaySound (string clip){

        switch(clip){
          case"Schlag":
            audioSrc.PlayOneShot(Schlag);
            break;
          case"hit":
            audioSrc.PlayOneShot(hit);
            break;
        }

    }
}
