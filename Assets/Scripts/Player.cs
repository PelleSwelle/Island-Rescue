using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }
    bool hasWon = false;
    public Stamina stamina;
    public GameObject deadScreen;
    public GameObject winScreen;
    public GameObject introScreen;
    public Transform waterTransform;


    bool hasDrowned;

    public float overWaterThreshold;
    public bool isInWater;

    void Awake() => Instance = this;

    void Start()
    {
        hasDrowned = false;
        deadScreen.SetActive(false);
        winScreen.SetActive(false);
    }

    void Update()
    {
        hasWon = ScoreScript.currentScore >= ScoreScript.requiredToWin;

        isInWater = waterTransform.position.y > transform.position.y + overWaterThreshold;
        hasDrowned = stamina.currentStamina <= 0;

        if (!hasDrowned && !hasWon)
        {
            enableInteraction();

            if (isInWater)
                stamina.decrease();
            else
                stamina.increase();
        }
        else if (hasDrowned)
            deadScreen.SetActive(true);
        else if (hasWon)
            winScreen.SetActive(true);
    }

    void rescue(VillagerBehavior villager) 
    {
        villager.hasBeenRescued = true;
        villager.runForExtraction();
    } 
    void enableInteraction()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            float interactRange = 50f;
            Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);
            foreach (Collider collider in colliderArray) 
                if (collider.TryGetComponent(out VillagerBehavior villager)) 
                {
                    rescue(villager);
                    Debug.Log("rescued: " + villager.name);
                }
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            introScreen.SetActive(false);
        }
    }
}
