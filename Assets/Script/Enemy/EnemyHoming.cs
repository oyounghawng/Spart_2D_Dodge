using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHoming : Enemy
{
    public float moveSpeed = 0.0f;
    public GameObject player;

    private void Awake()
    {
        player = Managers.Object.Player;
    }
    /*
    private void Update()
    {
        if (player != null)
        {
            Vector3 direction = (player.transform.position - transform.position).normalized;

            transform.position += direction * moveSpeed * Time.deltaTime;
        }
    }

    public void SetInfo(GameObject go)
    {
        player = go;
    }
}