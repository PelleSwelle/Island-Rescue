using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteractable : MonoBehaviour
{
    Animator animator;
    public AudioSource source;
    public List<AudioClip> shouts;
    public Material aliveMat, deadMat;
    MeshRenderer meshRenderer;

    public Transform water;
    public Stamina stamina;
    public bool isDead, hasBeenRescued = true;
    
    float timeToScream;

    bool isUnderWater = false;

    void Awake() 
    {
        animator = GetComponent<Animator>(); 
        water = FindObjectOfType<RisingScript>().GetComponent<Transform>();
    }

    public void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.material = aliveMat;
        stamina.currentStamina = stamina.maxStamina;

        animator.Play("injured Hurting Idle");
        
        isDead = false;
        hasBeenRescued = false;
    }
    
    public void rescue()
    {
        hasBeenRescued = true;
        runForExtraction();
        ScoreScript.currentScore++;
    }

    void runForExtraction()
    {
        animator.Play("Injured Jog");
    }

    void Update()
    {
        isDead = stamina.isEmpty;
        isUnderWater = transform.position.y < water.position.y;
        timeToScream = Random.Range(1, 70);

        if (hasBeenRescued)
        {
            runForExtraction();
        }

        if (!isDead && !hasBeenRescued)
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
