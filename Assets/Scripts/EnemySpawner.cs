using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] float spawnInterval = 2f;
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] Transform parentEnemyTransform;

    private void Start()
    {
        StartCoroutine(SpawnCoroutine());
    }

    private IEnumerator SpawnCoroutine()
    {
        while(true)
        {
            var newEnemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            newEnemy.transform.parent = parentEnemyTransform;
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
