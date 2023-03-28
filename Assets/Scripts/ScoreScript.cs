using UnityEngine;
using TMPro;

public class ScoreScript : MonoBehaviour
{
    public TextMeshProUGUI scoreValue;
    public static int score;
    
    void Start()
    {
        score = 0;
        scoreValue.text = "Score: " + score.ToString();
    }

    void Update()
    {
        scoreValue.text = "Score: " + score.ToString();
    }
}
