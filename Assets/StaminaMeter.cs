using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StaminaMeter : MonoBehaviour
{
    Player player;

    // the child objects
    public TMP_Text amountText;
    public RectTransform barRectTransform;
    
    float position;
    Vector2 staminaEndPosition; // the full length of the parent object
    public float startWidth;

    void Awake()
    {
        player = FindObjectOfType<Player>();
        startWidth = 204;
    }

    void Update()
    {
        updateText();
        updateBar();
    }

    void updateBar() 
    {
        position = mapRange(100, 0, startWidth, 0, player.stamina.currentStamina);
        barRectTransform.offsetMax = new Vector2(position, barRectTransform.offsetMax.y);
    }

    void updateText()
    {
        int roundedStamina = (int) player.stamina.currentStamina;
        amountText.text = roundedStamina.ToString();
    }  

    // utility function for mapping the stamina to the length of the stamina bar
    public static float mapRange(float inStart, float inEnd, float outStart, float outEnd, float value)
    {
        float scale = (outEnd - outStart) / (inEnd - inStart);
        return (outStart + ((value - inStart) * scale));
    }
}
