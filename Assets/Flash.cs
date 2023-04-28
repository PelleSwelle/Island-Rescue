using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flash : MonoBehaviour
{
    public Light lightning;

    public int timeToThunder;
    public AudioSource source1;
    public List<AudioClip> thunderSounds;

    void Awake() => lightning = GetComponent<Light>();

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
        lightning.enabled = true;
        yield return new WaitForSeconds(.5f);

        lightning.enabled = false;
    }
    void playThunder()
    {
        if (!source1.isPlaying)
            source1.PlayOneShot(thunderSounds[Random.Range(0, thunderSounds.Count)]);
    }
        
        

}