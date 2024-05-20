using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMob : MonoBehaviour
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

    public void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigid = GetComponent<Rigidbody2D>();
        rigid.velocity = Vector2.down * speed;
    }
    private void Update()
    {
        transform.position += moveDirection * moveSpeed * Time.deltaTime;

        if (transform.position.y < -6f)
        {
            Destroy(gameObject);
        }
    }
    public void OnHit(int dmg)
    {
        health -= dmg;
        spriteRenderer.sprite = sprites[1];
        Invoke("ReturnSprite", 0.1f);

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void moveTo(Vector3 direction)
    {
        moveDirection = direction;
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
            OnHit(bullet.dmg);
        }


    }

}