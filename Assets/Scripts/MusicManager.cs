using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    public AudioSource myAudioSource;

    // Method to keep music active through scenes
    
    void Awake()
    {
        DontDestroyOnLoad(myAudioSource);
    }
    

    // Turns music off if in scene index 4 or 5
    
    
    void StopMusic()
    {
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            myAudioSource.Stop();
        }
        if (SceneManager.GetActiveScene().buildIndex == 5)
        {
            myAudioSource.Stop();
        }
    }

    
    /*
    void RestartMainMusic()
    {
        if (SceneManager.GetActiveScene().buildIndex == 3 && myAudioSource != myAudioSource.isPlaying);
        {
          myAudioSource.Play();
        }
        
    }
    */
    
    private void Update()
    {
        StopMusic();
        //RestartMainMusic();
    }
    
}
