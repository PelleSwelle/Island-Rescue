using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class VillagerBehavior : MonoBehaviour
{
    public AudioSource source;
    public List<AudioClip> shouts;
    public NavMeshAgent agent;

    public Transform water, extractionPoint;
    public Stamina stamina;
    public bool isDead, hasBeenRescued = true;
    
    float timeToScream;

    bool isUnderWater = false;

    void Awake() 
    {
        water = GameObject.Find("SeaVisual").transform;
        source = GetComponent<AudioSource>();
        stamina = GetComponent<Stamina>();
        agent = GetComponent<NavMeshAgent>();
        extractionPoint = GameObject.Find("ExtractionPoint").transform;
    }

    public void Start()
    {
        stamina.currentStamina = stamina.maxStamina;
        isDead = false;
        hasBeenRescued = false;
    }
    
    void runForExtraction()
    {
        Debug.Log("running for extraction");
        agent.destination = extractionPoint.position;
        float dist = agent.remainingDistance; 
        
        if (dist <= 2)
            GameObject.Destroy(this);
    }

    void Update()
    {
        isDead = stamina.isEmpty;
        isUnderWater = transform.position.y < water.position.y;
        timeToScream = Random.Range(1, 70);

        if (hasBeenRescued) 
            runForExtraction();

        if (!isDead && !hasBeenRescued)
        {
            if (isUnderWater)
                stamina.decrease();
            
            playVoiceAtRandomTime();
        }
        if (isDead)
            transform.rotation = new Quaternion(0, 0, 90, 0);
    }

    void playVoiceAtRandomTime()
    {
        if (!source.isPlaying) // check if playing already
            if ((int)timeToScream == 3) // random value TODO: change this
                source.PlayOneShot(shouts[Random.Range(0, shouts.Count)]);
    }
}
