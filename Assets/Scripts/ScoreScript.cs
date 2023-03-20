using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ScoreScript : MonoBehaviour
{

    
    public TextMeshProUGUI scoreValue;
    public static int score;
    
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        scoreValue.text = "Score: " + score.ToString();
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreValue.text = "Score: " + score.ToString();
    }
}
