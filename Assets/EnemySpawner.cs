using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

public class EnemySpawner : MonoBehaviour
{
    [FormerlySerializedAs("bubblePrefab")] [SerializeField] private GameObject enemyPrefab;
    [SerializeField, Range(1, 10)] private float spawnTime = 3f;
    private bool isSpawningEnemy;
    [SerializeField] private bool spawnLeft;

    // Update is called once per frame
    void Update()
    {
        if (!isSpawningEnemy) StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        isSpawningEnemy = true;
        yield return new WaitForSeconds(spawnTime);
        GameObject enemy = Instantiate(enemyPrefab, transform.position, transform.rotation);
        if (spawnLeft)
        {
            Enemy enemyScript = enemy.GetComponent<Enemy>();
            enemyScript.moveLeft = true;
        }
        isSpawningEnemy = false;
    }
}
