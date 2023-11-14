using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAudio : MonoBehaviour
{
    
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.Play();
        Destroy(gameObject);
    }
    

    // Update is called once per frame
   
}
