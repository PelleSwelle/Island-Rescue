using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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
}
