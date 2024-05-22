using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public float health;

    protected Rigidbody2D rigid;
    protected GameObject player;

    protected void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        rigid.velocity = Vector2.down * speed;
    }

    protected void Update()
    {
        if (transform.position.y < -13f)
        {
            Managers.Resource.Destroy(gameObject);
        }
    }
    public void OnHit(int dmg)
    {
        health -= dmg;
        if (health <= 0)
            {
            return;
            }
        int ran = Random.Range(0, 10);
        GameObject go = null;
        if (ran < 3) 
        {
            
        }
        else if(ran < 5)
        {
             go = Managers.Resource.Instantiate("Item/Item Coin");// 아이템 랜덤으로 떨어지는거 만들기

        }
        else if(ran < 8)
        {
            go = Managers.Resource.Instantiate("Item/Item Boom");
        }
        else if (ran < 10) 
        {
            go = Managers.Resource.Instantiate("Item/Item Power");
        }
        if(go  != null)
            go.transform.position = this.transform.position;

        Destroy(gameObject);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerLimit")
            Destroy(gameObject);
        else if (collision.gameObject.tag == "Bullet")
        {
            Bullet bullet = collision.gameObject.GetComponent<Bullet>();
            OnHit(bullet.dmg);
        }
    }
}
