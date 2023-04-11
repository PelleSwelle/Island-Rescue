using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flash : MonoBehaviour
{
    Light testLight;
    public float minWaitTime;
    public float maxWaitTime;
    public float turnOffInterval;

    public AudioSource source1;
    public List<AudioClip> thunderSounds;

    float timeToThunder;
    bool lightYes = true;

    // Start is called before the first frame update
    void Start()
    {
        testLight = GetComponent<Light>();
        StartCoroutine(Flashing());
    }

    IEnumerator Flashing()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minWaitTime, maxWaitTime));
            testLight.enabled = !testLight.enabled;
            yield return new WaitForSeconds(turnOffInterval);
            testLight.enabled = false;
            lightYes = false;
            playThunderAtRandomTime();

        }
    }

    // Update is called once per frame
    void Update()
    {
        
        

    }


    void playThunderAtRandomTime()
    {
        if (!source1.isPlaying) // check if playing already
            if (lightYes == true) // random value TODO: change this
                source1.PlayOneShot(thunderSounds[Random.Range(0, thunderSounds.Count)]);
    }
}