using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class Enemy : MonoBehaviour
{
    public float speed;
    public float health;
    public Sprite[] sprites;

    SpriteRenderer spriteRenderer;
    Rigidbody2D rigid;

    protected void Awake()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        rigid = GetComponent<Rigidbody2D>();
        rigid.velocity = Vector2.down * speed;
    }

    protected void Update()
    {
        if (transform.position.y < -6f)
        {
           Managers.Resource.Destroy(gameObject);
        } 
    }
    public void OnHit(float dmg)
    {
        health -= dmg;
        //spriteRenderer.sprite = sprites[0];
        Invoke("ReturnSprite", 0.1f);
        if (health <= 0)
        {
            Destroy(gameObject);
            Managers.Resource.Instantiate("Item/Item Boom");// 아이템 랜덤으로 떨어지는거 만들기
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
        else if (collision.gameObject.tag == "Bullet")
        {
            Bullet bullet = collision.gameObject.GetComponent<Bullet>();
            //OnHit(bullet.dmg);
        }
    }
}
