using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemyManager : MonoBehaviour
{
    public GameObject enemyMobPrefab;

    public float mobSpawnTime;

    public GameObject enemyHomingPrefab;

    public float homingSpawnTime;

    public GameObject enemyBossPrefab;

    public bool spawnBoss = false;

    public GameObject player;



    private void Awake()
    {
        enemyMobPrefab = Managers.Resource.Load<GameObject>("Prefabs/Enemy/EnemyMob");
        mobSpawnTime = 3f;
        enemyHomingPrefab = Managers.Resource.Load<GameObject>("Prefabs/Enemy/EnemyHoming");
        homingSpawnTime = 8f;
        enemyBossPrefab = Managers.Resource.Load<GameObject>("Prefabs/Enemy/EnemyBoss");

        player = Managers.Object.Player;

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
            GameObject enemy = Managers.Instantiate(enemyMobPrefab, this.transform);
            enemy.transform.position = new Vector3(positionX, 7.4f, 0.0f);

            yield return new WaitForSeconds(mobSpawnTime);
        }
    }

    private IEnumerator SpawnHoming()
    {
        while (true)
        {
            float positionX = Random.Range(-2.4f, 2.4f);
            GameObject enemy = Managers.Instantiate(enemyHomingPrefab, this.transform);
            enemy.transform.position = new Vector3(positionX, 7.4f, 0.0f);
            EnemyHoming enemyHoming = Util.GetOrAddComponent<EnemyHoming>(enemy);
            enemyHoming.SetInfo(player);

            yield return new WaitForSeconds(homingSpawnTime);
        }
    }

    private void SpawnBoss()
    {
        Instantiate(enemyBossPrefab, new Vector3(0f, 8f, 0f), Quaternion.identity);
    }

    private IEnumerator BossCooldown()
    {
        yield return new WaitForSeconds(150f);
        spawnBoss = false;
    }
}