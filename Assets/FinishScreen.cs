using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FinishScreen : MonoBehaviour
{
    TMP_Text text;

    void Awake() => text = transform.GetChild(0).GetComponent<TMP_Text>();

    void Update()
        => text.text = "You saved " + ScoreScript.currentScore + "Villagers";
    
}
