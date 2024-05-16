using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab;
    [SerializeField]
    private GameObject bossPrefab; // ���� ������ ����
    [SerializeField]
    private float spawnTime = 2.5f;
    [SerializeField]
    private GameObject player; // �÷��̾� ������Ʈ ����
    private bool spawnBoss = false; // ���� ���� ����

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

            // ���� �ð��� ������ ���� ����
            if (!spawnBoss && timer >= 150f && timer < 600f && Mathf.Floor(timer) % 150f == 0) // ���� ���� �ð��� ���缭 ���� ����
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