using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    bool hasWon = false;
    public Stamina stamina;
    public GameObject deadScreen;
    public GameObject winScreen;
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

        // 

        if (transform.position.y <= waterTransform.position.y - 1.2f)
        {
            transform.position = new Vector3(transform.position.x, waterTransform.position.y - 1.2f, transform.position.z);

            Debug.Log("Text: ");
        }

        Debug.Log(transform.position.y);
        Debug.Log(waterTransform.position.y);







    }

    void enableInteraction()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            float interactRange = 2f;
            Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);
            foreach (Collider collider in colliderArray)
                if (collider.TryGetComponent(out NPCInteractable npcInteractable))
                    npcInteractable.rescue();
        }
    }
}
