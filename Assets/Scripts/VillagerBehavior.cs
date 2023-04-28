using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class VillagerBehavior : MonoBehaviour
{
    [SerializeField] Transform extractionPoint;
    public AudioSource source;
    public List<AudioClip> shouts;
    NavMeshAgent agent;

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
    }

    public void Start()
    {
        stamina.currentStamina = stamina.maxStamina;
        isDead = false;
        hasBeenRescued = false;
    }
    
    public void runForExtraction() => agent.destination = extractionPoint.position;

    void Update()
    {
        isDead = stamina.isEmpty;
        isUnderWater = transform.position.y < water.position.y;
        timeToScream = Random.Range(1, 70);

        if (hasBeenRescued) 
            runForExtraction();

        if (!isDead && !hasBeenRescued)
        {
            if (isUnderWater) { stamina.decrease(); }
            
            playVoiceAtRandomTime();
        }
        if (isDead)
            lieDown();
    }

    void lieDown() => transform.rotation = new Quaternion(0, 0, 90, 0);

    void playVoiceAtRandomTime()
    {
        if (!source.isPlaying) // check if playing already
            if ((int)timeToScream == 3) // random value TODO: change this
                source.PlayOneShot(shouts[Random.Range(0, shouts.Count-1)]);
    }
}
