using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab;
    [SerializeField]
    private GameObject bossPrefab; // 보스 프리팹 연결
    [SerializeField]
    private float spawnTime = 2.5f;
    [SerializeField]
    private GameObject player; // 플레이어 오브젝트 참조
    private bool spawnBoss = false; // 보스 생성 여부

    private void Awake()
    {
        StartCoroutine(SpawnEnemy());
    }

    private IEnumerator SpawnEnemy()
    {
        float timer = 0f;

        while (true)
        {
            if (!spawnBoss)
            {
                float positionX = Random.Range(-2.4f, 2.4f);
                GameObject enemy = Instantiate(enemyPrefab, new Vector3(positionX, 7.4f, 0.0f), Quaternion.identity);
                EnemyMob enemyMob = enemy.GetComponent<EnemyMob>();

                if (enemyMob != null && player != null)
                {
                    Vector3 direction = (player.transform.position - enemy.transform.position).normalized;
                    enemyMob.moveTo(direction);
                }
            }

            yield return new WaitForSeconds(spawnTime);
            timer += spawnTime;

            // 일정 시간이 지나면 보스 생성
            if (!spawnBoss && timer >= 150f && timer < 600f && Mathf.Floor(timer) % 150f == 0) // 보스 생성 시간에 맞춰서 보스 생성
            {
                spawnBoss = true;
                SpawnBoss();
            }
        }
    }

    private void SpawnBoss()
    {
        Instantiate(bossPrefab, new Vector3(0f, 8f, 0f), Quaternion.identity);
    }
}