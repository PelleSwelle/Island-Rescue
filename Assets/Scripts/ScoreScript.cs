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
        else 
            scoreText.text = "You have saved " + requiredToWin.ToString() + ". Time to get out!";
    }
}
