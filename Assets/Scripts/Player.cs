using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    bool hasWon = false;
    public Stamina stamina;
    public GameObject deadScreen;
    public GameObject winScreen;
    public GameObject introScreen;
    public Transform waterTransform;


    bool hasDrowned;

    public float overWaterThreshold;
    bool isInWater;

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

    void rescue(NPCInteractable npc) => npc.hasBeenRescued = true;
    void enableInteraction()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            float interactRange = 2f;
            Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);
            foreach (Collider collider in colliderArray) 
                if (collider.TryGetComponent(out NPCInteractable npcInteractable)) 
                    rescue(npcInteractable);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            introScreen.SetActive(false);
        }
    }
}
