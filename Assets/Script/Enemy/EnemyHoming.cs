using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHoming : Enemy
{
    public float moveSpeed = 0.0f;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

    }
    private new void Update()
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