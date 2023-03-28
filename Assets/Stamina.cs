using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stamina: MonoBehaviour
{
    public float currentStamina;
    public float maxStamina;
    public float decreaseRate, increaseRate;
    public bool isEmpty = false;

    void Start() => currentStamina = maxStamina;

    public void decrease() 
    {
        if (currentStamina > 0)
            currentStamina -= decreaseRate * Time.deltaTime;
        else 
            isEmpty = true;
    }
    public void increase() 
    {
        if (currentStamina < maxStamina)
            currentStamina += increaseRate * Time.deltaTime;
        else
            currentStamina = maxStamina;
    } 
}
