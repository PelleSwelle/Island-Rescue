using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class ScoreScript : MonoBehaviour
{

    public TextMeshProUGUI scoreValue;
    private int score;
    
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        scoreValue.text = "Score: " + score;
    }

    // Update is called once per frame
    void Update()
    {
    
    }
}
