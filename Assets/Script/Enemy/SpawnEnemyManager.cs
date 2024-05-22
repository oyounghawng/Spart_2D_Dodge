using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemyManager : MonoBehaviour
{
    private float mobSpawnTime;
    private float homingSpawnTime;
    private bool spawnBoss = false;
    private GameObject player;

    [SerializeField] private Transform spawnPoint1;
    [SerializeField] private Transform spawnPoint2;
    [SerializeField] private Transform spawnPoint3;
    [SerializeField] private Transform BossPoint;


    private void Awake()
    {
        mobSpawnTime = 1f;
        homingSpawnTime = 2f;
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

            if (!spawnBoss && timer >= 30f && timer % 30f < 1f)
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
            float positionX = Random.Range(-4.5f, 4.5f);
            GameObject enemy = Managers.Resource.Instantiate("Enemy/EnemyMob", this.transform);
            enemy.transform.position = new Vector3(positionX, spawnPoint1.position.y, 0.0f);
            yield return new WaitForSeconds(mobSpawnTime);
        }
    }

    private IEnumerator SpawnHoming()
    {
        while (true)
        {
            Transform spawnPoint = Random.Range(0, 3) == 0 ? spawnPoint1 : spawnPoint3;
            GameObject enemy = Managers.Resource.Instantiate("Enemy/EnemyHoming", this.transform);
            enemy.transform.position = spawnPoint.position;
            EnemyHoming enemyHoming = Util.GetOrAddComponent<EnemyHoming>(enemy);
            enemyHoming.SetInfo(player);

            yield return new WaitForSeconds(homingSpawnTime);
        }
    }

    private void SpawnBoss()
    {
        GameObject go = Managers.Resource.Instantiate("Enemy/EnemyBoss", this.transform);
        go.transform.position = BossPoint.position;
    }

    private IEnumerator BossCooldown()
    {
        yield return new WaitForSeconds(150f);
        spawnBoss = false;
    }
}