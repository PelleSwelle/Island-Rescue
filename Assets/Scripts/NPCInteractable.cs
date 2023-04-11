using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteractable : MonoBehaviour
{
    public AudioSource source;
    public List<AudioClip> shouts;
    public Material aliveMat, deadMat;
    MeshRenderer meshRenderer;

    public Transform water;
    public Stamina stamina;
    bool isDead, isRescued;
    
    float timeToScream;

    bool isUnderWater = false;

    void Awake() => water = FindObjectOfType<RisingScript>().GetComponent<Transform>();

    public void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.material = aliveMat;
        stamina.currentStamina = stamina.maxStamina;
        isDead = false;
        isRescued = false;
    }
    
    public void Interact()
    {
        isRescued = true;
        Destroy(gameObject);
        ScoreScript.score++;
    }

    void Update()
    {
        isDead = stamina.isEmpty;
        isUnderWater = transform.position.y < water.position.y;
        timeToScream = Random.Range(1, 50);

        if (!isDead && !isRescued)
        {
            if (isUnderWater)
                stamina.decrease();
            
            playVoiceAtRandomTime();
        }
        if (isDead)
            meshRenderer.material = deadMat;
    }

    void playVoiceAtRandomTime()
    {
        if (!source.isPlaying) // check if playing already
            if ((int)timeToScream == 3) // random value TODO: change this
                source.PlayOneShot(shouts[Random.Range(0, shouts.Count)]);
    }
}
