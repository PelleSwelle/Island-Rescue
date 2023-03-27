using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stamina: MonoBehaviour
{
    public float currentStamina;
    public float maxStamina;
    public float decreaseRate, increaseRate;

    void Start() => currentStamina = maxStamina;

    public void decrease() => currentStamina -= decreaseRate * Time.deltaTime;
    public void increase() 
    {
        if (currentStamina < maxStamina)
            currentStamina += increaseRate * Time.deltaTime;
    } 
}
