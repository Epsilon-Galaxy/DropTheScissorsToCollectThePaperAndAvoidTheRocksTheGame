using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    private string gameSceneName = "GameScene";
    private string menuSceneName = "GameMenu";

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GoToMenu();
        }
    }

    public void PlayGame()
    {
        Debug.Log("PlayGame button clicked");
        SceneManager.LoadScene(gameSceneName);
    }

    public void RestartGame()
    {
        ResetGameData();

        RandomGenManager randomGenManager = FindObjectOfType<RandomGenManager>();
        if (randomGenManager != null)
        {
            randomGenManager.ResetGameObjects();
        }

        SceneManager.LoadScene(gameSceneName);
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene(menuSceneName);
    }

    private void ResetGameData()
    {
        ScoreKeeper scoreKeeper = FindObjectOfType<ScoreKeeper>();
        if (scoreKeeper != null)
        {
            scoreKeeper.score = 0;
            scoreKeeper.scissorsUsed = 0;
            scoreKeeper.totalPapers = 0;
        }
    }
}
