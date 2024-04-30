using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance;  // Singleton instance

    void Awake()
    {
        // Check if an instance already exists
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        // Set the instance
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        // Play audio here (e.g., background music)
        PlayAudio();
    }

    void PlayAudio()
    {
        // Play your audio using the AudioSource component attached to this game object
        // For example:
        GetComponent<AudioSource>().Play();
    }

}
