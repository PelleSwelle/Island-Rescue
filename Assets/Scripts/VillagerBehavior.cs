using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class VillagerBehavior : MonoBehaviour
{
    Animator animator;
    [SerializeField] Transform extractionPoint;
    public AudioSource source;
    public List<AudioClip> shouts;
    [SerializeField] NavMeshAgent agent;

    public Transform water;
    public Stamina stamina;
    public bool isDead, hasBeenRescued = true;
    
    float timeToScream;

    bool isUnderWater = false;

    void Awake() 
    {
        water = GameObject.Find("SeaVisual").GetComponent<Transform>();
        source = GetComponent<AudioSource>();
        stamina = GetComponent<Stamina>();
        agent = GetComponent<NavMeshAgent>();
        extractionPoint = GameObject.FindGameObjectWithTag("extractionPoint").transform;

        if (GetComponent<Animator>() == null)
        {
            animator = gameObject.AddComponent<Animator>();
            Debug.Log("added animator");
        }
        else 
            animator = GetComponent<Animator>();
        
    }

    public void Start()
    {
        stamina.currentStamina = stamina.maxStamina;
        isDead = false;
        hasBeenRescued = false;
        animator.Play("Injured Idle");
    }

    void Update()
    {
        isDead = stamina.isEmpty;
        isUnderWater = transform.position.y < water.position.y;
        timeToScream = Random.Range(1, 300);

        if (!isDead && !hasBeenRescued)
        {
            if (isUnderWater) { stamina.decrease(); }
            playVoiceAtRandomTime();
        }
        if (isDead)
            animator.Play("Falling");
    }

    public void sayThankYou()
    {
        animator.Play("Thankful");
    }
    
    public void runForExtraction() 
    {
        if (extractionPoint == null) { throw new System.Exception("extractionPoint not set"); }
        sayThankYou();
        
        // agent.destination = extractionPoint.position;
        // if (this.tag == "villager/1" || this.tag == "villager/4")   animator.Play("Injured Run");
        // else if (this.tag == "villager/2")                          animator.Play("Injured Walking");
        // else if (this.tag == "villager/3")                          animator.Play("Injured Jog");
    }

    

    void lieDown() => transform.rotation = new Quaternion(0, 0, 90, 0);

    public void onBeingRescued() 
    { 
        sayThankYou();
        hasBeenRescued = true; 
        runForExtraction(); 
    }

    void playVoiceAtRandomTime()
    {
        if (!source.isPlaying) // check if playing already
            if ((int)timeToScream == 3) // random value TODO: change this
                source.PlayOneShot(getRandomShout());    
    }

    AudioClip getRandomShout()
    {
        int random = (int) Random.Range(1, shouts.Count -1);
        return shouts[random];
    }
}
