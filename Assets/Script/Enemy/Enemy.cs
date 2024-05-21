using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public float health;
    public Sprite[] sprites;

    SpriteRenderer spriteRenderer;
    Rigidbody2D rigid;

    public GameObject Coin;
    public GameObject Boom;
    public GameObject Power;

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
            return;
        }
        int ran = Random.Range(0, 10);
        if (ran < 3) 
        {
            Debug.Log("Not Item");
            
        }
        else if(ran < 5)
        {
            Managers.Resource.Instantiate("Item/Item Coin");// 아이템 랜덤으로 떨어지는거 만들기
        }
        else if(ran < 8)
        {
            Managers.Resource.Instantiate("Item/Item Boom");
        }
        else if (ran < 10) 
        {
            Managers.Resource.Instantiate("Item/Item Power");
        }
        Destroy(gameObject);


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
