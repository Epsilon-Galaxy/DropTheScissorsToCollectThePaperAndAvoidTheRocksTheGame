using UnityEngine;

public class LivesTracker : MonoBehaviour
{
    public GameObject[] ScissorsUsed; // Reference to the UI elements or game objects indicating remaining lives
    private int livesRemaining;

    private void Start()
    {
        // Initialize lives count based on the number of ScissorsUsed objects
        livesRemaining = ScissorsUsed.Length;
    }

    // Call this method when scissors are dropped
    public bool UseLife()
    {
        if (livesRemaining > 0)
        {
            livesRemaining--;

            // Disable one of the ScissorsUsed objects to visually indicate life lost
            ScissorsUsed[livesRemaining].SetActive(false);

            return true; // Indicate that a life was successfully used
        }
        else
        {
            // No lives remaining
            Debug.Log("No more lives left!");
            return false; // Indicate that no lives are available
        }
    }
}
