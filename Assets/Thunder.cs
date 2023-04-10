using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thunder : MonoBehaviour
{

    public AudioSource source1;
    public List<AudioClip> thunderSounds;

    float timeToThunder;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeToThunder = Random.Range(1, 10);

        playThunderAtRandomTime();
    }


    void playThunderAtRandomTime()
    {
        if (!source1.isPlaying) // check if playing already
            if ((int)timeToThunder == 3) // random value TODO: change this
                source1.PlayOneShot(thunderSounds[Random.Range(0, thunderSounds.Count)]);
    }
}
