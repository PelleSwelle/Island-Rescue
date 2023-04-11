using UnityEngine;
using TMPro;

public class ScoreScript : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public static int currentScore;
    public static int requiredToWin = 10;
    
    void Start()
    {
        currentScore = 0;
        scoreText.text = "Score: " + currentScore.ToString();
    }

    void Update()
    {
        if (currentScore < requiredToWin)
            scoreText.text = "Score: " + currentScore.ToString();
    }
}
