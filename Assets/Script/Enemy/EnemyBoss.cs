using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoss : MonoBehaviour
{
    public float speed;
    public int health;

    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rigid;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigid = GetComponent<Rigidbody2D>();
        rigid.velocity = Vector2.down * speed;
    }

    private void Start()
    {
        Invoke("Stop", 3f);
    }

    private void Stop()
    {   
        if (!gameObject.activeSelf)
            return;
        rigid.velocity = Vector2.zero;
    }
    public void OnHit(int dmg = 10)
    {
        health -= dmg;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "BorderBullet")
        {
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "PlayerBullet")
        {
            Bullet bullet = collision.gameObject.GetComponent<Bullet>();
            OnHit();
            Destroy(collision.gameObject);
        }
    }
}