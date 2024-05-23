using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyHoming : Enemy
{
    private float moveSpeed = 0.0f;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        moveSpeed = 4f;
    }
    private new void Update()
    {
        if (player != null)
        {
            Vector3 direction = (player.transform.position - transform.position).normalized;
            transform.position += direction * moveSpeed * Time.deltaTime;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        }
    }
    public void SetInfo(GameObject go)
    {
        player = go;
    }
}