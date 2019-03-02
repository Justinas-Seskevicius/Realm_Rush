using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] float spawnInterval = 2f;
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] Transform parentEnemyTransform;
    [SerializeField] int scorePerSpawn = 15;
    [SerializeField] Text scoreText;
    [SerializeField] AudioClip spawnSFX;

    int score = 0;

    private void Start()
    {
        StartCoroutine(SpawnCoroutine());
        UpdateScoreText();
    }

    private IEnumerator SpawnCoroutine()
    {
        while(true)
        {
            var newEnemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            newEnemy.transform.parent = parentEnemyTransform;
            GetComponent<AudioSource>().PlayOneShot(spawnSFX);
            score += scorePerSpawn;
            UpdateScoreText();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private void UpdateScoreText()
    {
        scoreText.text = score.ToString();
    }
}
