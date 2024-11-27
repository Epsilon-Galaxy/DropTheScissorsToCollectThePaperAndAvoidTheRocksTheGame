using UnityEngine;
using TMPro; // For TextMeshPro

public class ScoreKeeper : MonoBehaviour
{
    public int score = 0;  // Total score
    public int scissorsUsed = 0;  // Total scissors used
    public int totalPapers = 0;  // Total papers collected
    public int requiredPapers;  // Total number of papers in the game

    public TextMeshProUGUI scoreText; // Reference to the TextMeshPro UI element

    private void Start()
    {
        UpdateScoreText(); // Ensure the score is displayed correctly at the start
    }

    // Method to increment the score when a paper is collected
    public void IncrementScore()
    {
        score++;
        totalPapers++;
        UpdateScoreText();

        // Check if all papers are collected
        if (totalPapers == requiredPapers)
        {
            ApplyMultiplier();
        }
    }

    // Method to apply score multiplier based on scissors usage
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

        // Update the score text with the multiplier applied
        UpdateScoreText();
        Debug.Log("Final Score: " + score);
    }

    // Method to track scissors usage
    public void UseScissors()
    {
        scissorsUsed++;
    }

    // Method to update the score UI text
    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + score.ToString(); // Update the UI text with the "Score:" prefix
    }
}
