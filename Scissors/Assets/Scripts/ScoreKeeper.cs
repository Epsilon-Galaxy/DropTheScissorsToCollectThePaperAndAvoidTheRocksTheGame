using UnityEngine;
using TMPro;

public class ScoreKeeper : MonoBehaviour
{
    public int score = 0;
    public int scissorsUsed = 0;
    public int totalPapers = 0;
    public int requiredPapers;

    public TextMeshProUGUI scoreText;

    private void Start()
    {
        UpdateScoreText();
    }

    public void IncrementScore()
    {
        score++;
        totalPapers++;
        UpdateScoreText();

        if (totalPapers == requiredPapers)
        {
            ApplyMultiplier();
        }
    }

    private void ApplyMultiplier()
    {
        if (scissorsUsed == 1)
        {
            score *= 3;
        }
        else if (scissorsUsed == 2)
        {
            score *= 2;
        }

        UpdateScoreText();
        Debug.Log("Final Score: " + score);
    }

    public void UseScissors()
    {
        scissorsUsed++;
    }

    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }
}
