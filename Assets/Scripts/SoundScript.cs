using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundScript : MonoBehaviour
{
    public AudioSource soundEffects; //The current sound
    public AudioClip sound1, sound2; //All the different sounds

    public void Sound1()
    {
        soundEffects.clip = sound1; //Change the current sound to sound 1
        soundEffects.Play(); //Play sound
    }

    public void Sound2()
    {
        soundEffects.clip = sound2; //Change th current sound to sound 2
        soundEffects.Play(); //Play sound
    }
}
