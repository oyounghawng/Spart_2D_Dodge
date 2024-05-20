using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemyManager : MonoBehaviour
{
    protected GameObject EnemyPrefab;
    GameObject player;
    private void Awake()
    {
        player = Managers.Object.Player;
    }
}
