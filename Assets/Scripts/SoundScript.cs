using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundScript : MonoBehaviour
{
    public AudioSource soundEffects;
    public AudioClip sfx1, sfx2;

    public void Sound1()
    {
        soundEffects.clip = sfx1;
        soundEffects.Play();
    }

    public void Sound2()
    {
        soundEffects.clip = sfx2;
        soundEffects.Play();
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
