using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMob : Enemy
{
    public float speed;
    public int health;
    public Sprite[] sprites;
    [SerializeField]
    private float moveSpeed = 0.0f;
    [SerializeField]
    private Vector3 moveDirection = Vector3.zero;
    SpriteRenderer spriteRenderer;
    Rigidbody2D rigid;
    /*
    private void Update()
    {
        transform.position += moveDirection * moveSpeed * Time.deltaTime;

        if (transform.position.y < -6f)
        {
            Destroy(gameObject);
        }
    }
    */
    public void moveTo(Vector3 direction)
    {
        moveDirection = direction;
    }
}