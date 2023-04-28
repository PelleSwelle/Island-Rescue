using UnityEngine;
using TMPro;

public class ScoreScript : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public static int requiredToWin = 10;

    public static ScoreScript Instance;

    void Awake() => Instance = this;
    
    void Update()
        => scoreText.text = "Score: " + Player.Instance.villagersSaved.ToString();
}
