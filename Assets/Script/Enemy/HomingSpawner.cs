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
        enemyPrefab = Managers.Resource.Load<GameObject>("Prefabs/Enemy/EnemyHoming");
        player = Managers.Object.Player;
        spawnTime = 1f;
        StartCoroutine(SpawnEnemy());
    }

    private IEnumerator SpawnEnemy()
    {
        while (true)
        {
            float positionX = Random.Range(-2.4f, 2.4f);
            GameObject enemy = Managers.Instantiate(enemyPrefab, this.transform);
            enemy.transform.position = new Vector3(positionX, 7.4f, 0.0f);
            EnemyHoming enemyHoming =Util.GetOrAddComponent<EnemyHoming>(enemy);
            enemyHoming.SetInfo(player);
            yield return new WaitForSeconds(spawnTime);
        }
    }
}