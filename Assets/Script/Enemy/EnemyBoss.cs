using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoss : MonoBehaviour
{
    public float speed;
    public int health;
    public Sprite[] sprites;

    SpriteRenderer spriteRenderer;
    Rigidbody2D rigid;

    [SerializeField]
    private float moveSpeed = 1.5f;
    [SerializeField]
    private Vector3 moveDirection = Vector3.down;
    public void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigid = GetComponent<Rigidbody2D>();
        rigid.velocity = Vector2.down * speed;
    }


    private void Update()
    {
        if (transform.position.y > 7.4f)
        {
            transform.position = new Vector3(transform.position.x, 7.4f, transform.position.z);
        }
        else
        {
            transform.position += Vector3.down * moveSpeed * Time.deltaTime;
        }

            if (transform.position.y < -6f)
        {
            Destroy(gameObject);
        }
    }

    public void OnHit(int dmg = 10)
    {
        health -= dmg;
        spriteRenderer.sprite = sprites[1];
        Invoke("ReturnSprite", 0.1f);

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void ReturnSprite()
    {
        spriteRenderer.sprite = sprites[0];
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "BorderBullet")
            Destroy(gameObject);
        else if (collision.gameObject.tag == "PlayerBullet")
        {
            Bullet bullet = collision.gameObject.GetComponent<Bullet>();
            OnHit();
        }
    }
}