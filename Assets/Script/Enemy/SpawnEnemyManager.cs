using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemyManager : MonoBehaviour
{
    private float mobSpawnTime;
    private float homingSpawnTime;
    private bool spawnBoss = false;
    private GameObject player;

    private void Awake()
    {
        mobSpawnTime = 3f;
        homingSpawnTime = 8f;
        player = Managers.Object.Player;
    }

    private void Start()
    {
        StartCoroutine(SpawnEnemies());
    }
    private IEnumerator SpawnEnemies()
    {
        StartCoroutine(SpawnMob());
        StartCoroutine(SpawnHoming());

        float timer = 0f;

        while (true)
        {
            yield return null;
            timer += Time.deltaTime;

            if (!spawnBoss && timer >= 150f && timer % 150f < 1f)
            {
                spawnBoss = true;
                SpawnBoss();
                StartCoroutine(BossCooldown());
            }
        }
    }

    private IEnumerator SpawnMob()
    {
        while (true)
        {
            float positionX = Random.Range(-2.4f, 2.4f);
            GameObject enemy = Managers.Resource.Instantiate("Enemy/EnemyMob", this.transform);
            enemy.transform.position = new Vector3(positionX, 7.4f, 0.0f);
            yield return new WaitForSeconds(mobSpawnTime);
        }
    }

    private IEnumerator SpawnHoming()
    {
        while (true)
        {
            float positionX = Random.Range(-2.4f, 2.4f);
            GameObject enemy = Managers.Resource.Instantiate("Enemy/EnemyHoming", this.transform);
            enemy.transform.position = new Vector3(positionX, 7.4f, 0.0f);
            EnemyHoming enemyHoming = Util.GetOrAddComponent<EnemyHoming>(enemy);
            enemyHoming.SetInfo(player);

            yield return new WaitForSeconds(homingSpawnTime);
        }
    }

    private void SpawnBoss()
    {
        GameObject go = Managers.Resource.Instantiate("Enemy/EnemyBoss", this.transform);
        go.transform.position = new Vector3(0f, 8f, 0f);
    }

    private IEnumerator BossCooldown()
    {
        yield return new WaitForSeconds(150f);
        spawnBoss = false;
    }
}