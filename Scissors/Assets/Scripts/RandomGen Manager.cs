using UnityEngine;

public class RandomGenManager : MonoBehaviour
{
    // Singleton instance
    public static RandomGenManager Instance { get; private set; }

    [SerializeField]
    private GameObject _paperPrefab;

    [SerializeField] 
    private GameObject _rockPrefab;

    [SerializeField]
    private GameObject spawnArea;

    public int startingPaper;
    public int startingRock;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    private void Start()
    {
        ScoreKeeper scoreKeeper = FindObjectOfType<ScoreKeeper>();
        scoreKeeper.requiredPapers = startingPaper;

        for (int i = 0; i < startingPaper; i++)
        {
            GeneratePapers();
        }

        for (int i = 0; i < startingRock; i++)
        {
            GenerateRocks();
        }
    }

    public void GeneratePapers()
    {
        Bounds bounds = spawnArea.GetComponent<Renderer>().bounds;

        float randomX = Random.Range(bounds.min.x, bounds.max.x);
        float randomY = Random.Range(bounds.min.y, bounds.max.y);

        Vector3 randomPoint = new Vector3(randomX, randomY, 0);

        Instantiate(_paperPrefab, randomPoint, Quaternion.identity);
    }

    public void GenerateRocks()
    {
        Bounds bounds = spawnArea.GetComponent<Renderer>().bounds;

        float randomX = Random.Range(bounds.min.x, bounds.max.x);
        float randomY = Random.Range(bounds.min.y, bounds.max.y);

        Vector3 randomPoint = new Vector3(randomX, randomY, 0);

        Instantiate(_rockPrefab, randomPoint, Quaternion.identity);
    }

    public void ResetGameObjects()
    {
        ClearGameObjects();

        for (int i = 0; i < startingPaper; i++)
        {
            GeneratePapers();
        }

        for (int i = 0; i < startingRock; i++)
        {
            GenerateRocks();
        }
    }

    private void ClearGameObjects()
    {
        GameObject[] papers = GameObject.FindGameObjectsWithTag("Paper");
        foreach (GameObject paper in papers)
        {
            Destroy(paper);
        }

        GameObject[] rocks = GameObject.FindGameObjectsWithTag("Rock");
        foreach (GameObject rock in rocks)
        {
            Destroy(rock);
        }
    }
}
