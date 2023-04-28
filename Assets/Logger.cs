using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Logger : MonoBehaviour
{
    [SerializeField] TMP_Text isInWaterValue, drownedVillagersValue, savedVillagersValue, timeLeftValue;
    [SerializeField] GameObject villagersParent;

   
    void Update()
    {
        isInWaterValue.text = Player.Instance.isInWater.ToString();
        // drownedVillagersValue.text = getNumberOfDrowned().ToString() + " / " + villagersParent.transform.childCount;
        // savedVillagersValue.text = getNumberOfSaved().ToString() + " / " + villagersParent.transform.childCount;
    }

    // int getNumberOfSaved()
    // {
    //     int  number = 0;
        
    //     foreach (VillagerBehavior villager in villagersParent.transform)
    //         if (villager.GetComponent<VillagerBehavior>().hasBeenRescued) { number ++; }
       
    //     return number;
    // }

    // int getNumberOfDrowned()
    // {
    //     int number = 0;
       
    //     foreach(GameObject villager in villagersParent.transform)
    //         if (villager.GetComponent<VillagerBehavior>().isDead) { number ++; }
        
    //     return number;
    // }
}
