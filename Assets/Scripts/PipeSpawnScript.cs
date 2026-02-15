using UnityEngine;

public class PipeSpawnScript : MonoBehaviour
{
    [System.Serializable]
    public class PipeVariant
    {
        public GameObject pipePrefab;
        [Range(0f, 100f)]
        public float spawnWeight = 1f;  // Higher = more frequent
    }

    public PipeVariant[] pipeVariants;  // Array of pipe variants
    [SerializeField] private float spawnRate;
    public float timer = 0;
    public float heightOffset = 10;

    private float totalWeight;

    void Start()
    {
        CalculateTotalWeight();
        SpawnPipe();
    }

    void Update()
    {
        if (timer < spawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            SpawnPipe();
            timer = 0;
        }
    }

    void CalculateTotalWeight()
    {
        totalWeight = 0f;
        foreach (PipeVariant variant in pipeVariants)
        {
            totalWeight += variant.spawnWeight;
        }
    }

    GameObject GetRandomPipe()
    {
        float randomValue = Random.Range(0f, totalWeight);
        float cumulativeWeight = 0f;

        foreach (PipeVariant variant in pipeVariants)
        {
            cumulativeWeight += variant.spawnWeight;
            if (randomValue <= cumulativeWeight)
            {
                return variant.pipePrefab;
            }
        }

        // Fallback (shouldn't reach here)
        return pipeVariants[0].pipePrefab;
    }

    public void SpawnPipe()
    {
        float highestPoint = transform.position.y + heightOffset;
        float lowestPoint = transform.position.y - heightOffset;

        GameObject selectedPipe = GetRandomPipe();
        Instantiate(selectedPipe, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0), transform.rotation);
    }
}