using UnityEngine;

public class Player : MonoBehaviour
{
    public Stamina stamina;
    public GameObject deadScreen;

    public Transform waterTransform;

    bool hasDrowned;
    
    public float overWaterThreshold;
    bool isInWater;

    void Start() 
    {
        hasDrowned = false;
        deadScreen.SetActive(false);
    }
    
    void Update()
    {
        enableControls();
        
        isInWater = waterTransform.position.y > transform.position.y + overWaterThreshold;
        hasDrowned = stamina.currentStamina <= 0;
        
        if (!hasDrowned)
        {
            if (isInWater)
                stamina.decrease();
            else
                stamina.increase();
        }
        else 
            deadScreen.SetActive(true);
    }

    void enableControls()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            float interactRange = 2f;
            Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);
            foreach (Collider collider in colliderArray) 
                if (collider.TryGetComponent(out NPCInteractable npcInteractable)) 
                    npcInteractable.rescue();
        }
    }
}
