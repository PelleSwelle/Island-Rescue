using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flash : MonoBehaviour
{
    public Light lightning;

    public int timeToThunder;
    public AudioSource source1;
    public List<AudioClip> thunderSounds;

    void Awake()
        => lightning = GetComponent<Light>();

    void Start()
    {
        lightning.enabled = false;
    }

    void Update()
    {
        timeToThunder = Random.Range(0, 70);
        if (timeToThunder == 5) 
        { 
            playThunder(); 
            StartCoroutine(playLightning());
        }
    }
    IEnumerator playLightning()
    {
        //Print the time of when the function is first called.
        Debug.Log("lighning START at: " + Time.time);
        lightning.enabled = true;
        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(.5f);

        //After we have waited 5 seconds print the time again.
        Debug.Log("lightning END at: " + Time.time);
        lightning.enabled = false;
    }
    void playThunder()
    {
        if (!source1.isPlaying)
            source1.PlayOneShot(thunderSounds[Random.Range(0, thunderSounds.Count)]);
    }
        
        

}