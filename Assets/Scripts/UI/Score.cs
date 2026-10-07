using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public static Score Instance;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI highScoreText;
    private int score = 0;
    private int highScore;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        highScore = PlayerPrefs.GetInt("highscore", 0);
        scoreText.text = "Score: " + score.ToString();
        highScoreText.text = "Highscore: " + highScore.ToString();
    }

    public void AddScore(int points)
    {
        score += points;
        scoreText.text = "Score: " + score.ToString();
        if(score > highScore)
        {
            PlayerPrefs.SetInt("highscore", score);
        }
    }

}
