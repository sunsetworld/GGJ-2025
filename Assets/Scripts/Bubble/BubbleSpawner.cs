using System.Collections;
using UnityEngine;

public class BubbleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject bubblePrefab;
    [SerializeField, Range(1, 10)] private float spawnTime = 3f;
    private bool isSpawningBubble;

    // Update is called once per frame
    void Update()
    {
        if (!isSpawningBubble) StartCoroutine(SpawnBubble());
    }

    IEnumerator SpawnBubble()
    {
        isSpawningBubble = true;
        yield return new WaitForSeconds(spawnTime);
        Instantiate(bubblePrefab, transform.position, Quaternion.identity);
        isSpawningBubble = false;
    }
}
