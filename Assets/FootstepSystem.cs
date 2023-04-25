using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class FootstepSystem : MonoBehaviour
{

    public AudioSource AudioSource;

    public AudioClip gravel;


    RaycastHit hit;
    public Transform RayStart;
    public float range;
    public LayerMask layerMask;


    // Start is called before the first frame update
    public void footStep()
    {
        if(Physics.Raycast(RayStart.position, RayStart.transform.up * -1, out hit, range, layerMask))
        {
            if (hit.collider.CompareTag("Gravel"))
            {
                playFootstepSound(gravel);
            }
        }
       
    }


    void playFootstepSound(AudioClip audio)
    {
        AudioSource.pitch = Random.Range(0.8f, 1f);
        AudioSource.PlayOneShot(audio);

    }


    // Update is called once per frame
    void Update()
    {

    }
        
}
