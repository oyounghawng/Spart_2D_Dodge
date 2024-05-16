using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab;
    [SerializeField]
    private float spawnTime;
    [SerializeField]
    private GameObject player;  // 플레이어 오브젝트 참조

    private void Awake()
    {
        StartCoroutine(SpawnEnemy());
    }

    private IEnumerator SpawnEnemy()
    {
        while (true)
        {
            float positionX = Random.Range(-2.4f, 2.4f);
            GameObject enemy = Instantiate(enemyPrefab, new Vector3(positionX, 7.4f, 0.0f), Quaternion.identity);
            EnemyHoming movement = enemy.GetComponent<EnemyHoming>();

            if (movement != null)
            {
                movement.player = player;  // 플레이어 설정
            }

            yield return new WaitForSeconds(spawnTime);
        }
    }
}