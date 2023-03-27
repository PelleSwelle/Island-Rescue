using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteractable : MonoBehaviour
{
    public AudioClip clip1;
    public AudioClip clip2;
    public AudioClip clip3;
    public AudioClip clip4;
    public AudioClip clip5;
    public AudioSource source;
    float timeToScream;
    public void Interact()
    {
        Destroy(gameObject);
        ScoreScript.score++;
    }

    void Update()
    {
        timeToScream = Random.Range(1, 5);
        playVoiceAtRandomTime();
    }


    void playVoiceAtRandomTime()
    {
        if (!source.isPlaying) // check if playing already
        {
            if ((int)timeToScream == 3) // random value TODO: change this
            {
                source.PlayOneShot(clip1);
            }
        }
    }
}
