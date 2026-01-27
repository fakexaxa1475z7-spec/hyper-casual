using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject platformPrefab;
    public float spawnRate = 0.5f;
    public float heightOffset = 2.5f;

    void Start()
    {
        InvokeRepeating(nameof(SpawnPipe), 1f, spawnRate);
        InvokeRepeating(nameof(SpawnPlatform), 1f, Random.Range(0, 3));
    }

    void SpawnPipe()
    {
        float x = Random.Range(-heightOffset, heightOffset);
        Instantiate(platformPrefab, new Vector3(x, 5f, 0), Quaternion.identity);
    }
    void SpawnPlatform()
    {
        float x = Random.Range(-heightOffset, heightOffset);
        Instantiate(platformPrefab, new Vector3(x, 5f, 0), Quaternion.identity);
    }
}
