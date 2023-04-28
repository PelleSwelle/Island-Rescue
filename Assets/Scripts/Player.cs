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

    public int villagersSaved = 0;
    
    float interactRange = 5f;


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
        hasWon = villagersSaved >= ScoreScript.requiredToWin;

        isInWater = WaterBehavior.Instance.currentLevel > transform.position.y + overWaterThreshold;

        if (isInWater)
            transform.position = new Vector3(transform.position.x, WaterBehavior.Instance.currentLevel, transform.position.z);
        hasDrowned = stamina.currentStamina <= 0;

        if (!hasDrowned && !hasWon)
        {
            enableInputs();

            if (isInWater)      stamina.decrease();
            else                stamina.increase();
        }
        else if (hasDrowned)    deadScreen.SetActive(true);
        else if (hasWon)        winScreen.SetActive(true);
    }

    void rescue(VillagerBehavior villager) 
    {
        villagersSaved++;
        villager.sayThankYou();
        Destroy(villager.gameObject); 
    } 
    void enableInputs()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);
            foreach (Collider collider in colliderArray) 
            {
                if (collider.TryGetComponent(out VillagerBehavior villager)) 
                {
                    rescue(villager);
                    Debug.Log("rescued: " + villager.name);
                }
                else if (collider.tag == "helicopter")
                    endGame();
            }
        }

        if (introScreen.activeInHierarchy)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                introScreen.SetActive(false);
            }
        }
    }

    void endGame()
    {
        winScreen.SetActive(true);
    }
}
