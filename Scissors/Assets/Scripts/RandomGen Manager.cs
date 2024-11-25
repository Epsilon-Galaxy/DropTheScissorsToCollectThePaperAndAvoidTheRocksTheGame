using UnityEngine;

public class RandomGenManager : MonoBehaviour
{
    // Singleton instance
    public static RandomGenManager Instance { get; private set; }

    [SerializeField]
    private GameObject _paperPrefab;

    [SerializeField]
    private GameObject spawnArea;

    private int numberToSpawn;

    private void Awake()
    {
        // Ensure only one instance exists
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        DontDestroyOnLoad(gameObject);

        numberToSpawn = 10;
    }

    private void Start()
    {
        for (int i = 0; i < numberToSpawn; i++)
        {
            GeneratePapers();
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
}
