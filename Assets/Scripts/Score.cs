/*using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] EnemyAI enemyAI;
    private TextMeshProUGUI scoreText;
    private int score;

    private void Awake()
    {
        enemyAI = GetComponent<EnemyAI>();
        scoreText = GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
            scoreText = score;
            scoreText += enemyAI.EnemyDeathScore;
            print(score);
    }

}*/
