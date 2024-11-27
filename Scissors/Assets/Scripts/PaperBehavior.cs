using UnityEngine;

public class PaperBehavior : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ScoreKeeper scoreKeeper = FindObjectOfType<ScoreKeeper>();
            scoreKeeper.IncrementScore(); // Notify ScoreKeeper of score increment

            Destroy(gameObject); // Remove the paper after it's collected
        }
        else if (collision.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject); // Destroy paper if it hits a wall
            RandomGenManager.Instance.GeneratePapers(); // Generate a new paper
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);
            RandomGenManager.Instance.GeneratePapers();
        }
    }
}
