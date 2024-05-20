using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMob : Enemy
{
    public float moveSpeed = 0.0f;
    public Vector3 moveDirection = Vector3.down;

    new private void Update()
    {
        transform.position += moveDirection * moveSpeed * Time.deltaTime;

        if (transform.position.y < -6f)
        {
            Managers.Resource.Destroy(gameObject);
        }
    }
    public void moveTo(Vector3 direction)
    {
        moveDirection = direction;
    }
    new private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            Destroy(gameObject);
        }
    }
}