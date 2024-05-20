using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHoming : MonoBehaviour
{
    public float speed;
    public int health;
    public Sprite[] sprites;

    SpriteRenderer spriteRenderer;
    Rigidbody2D rigid;

    private float moveSpeed = 0.0f;
    private Vector3 moveDirection = Vector3.zero;
    private GameObject player;  // 플레이어 오브젝트 참조

    private void Start()
    {
        moveSpeed = 2.0f;
    }

    public void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigid = GetComponent<Rigidbody2D>();
        rigid.velocity = Vector2.down * speed;
    }

    private void Update()
    {
        if (player != null)
        {
            Vector3 direction = (player.transform.position - transform.position).normalized;  // 플레이어를 향하는 방향
            moveDirection = direction;
        }

        transform.position += moveDirection * moveSpeed * Time.deltaTime;

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


    public void SetInfo(GameObject go)
    {
        player = go;
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