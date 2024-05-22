using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    protected float health;
    protected float Maxhealth;

    protected Rigidbody2D rigid;
    protected GameObject player;

    protected virtual void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        rigid.velocity = Vector2.down * speed;
        Maxhealth = 2;
    }
    private void OnEnable()
    {
        health = Maxhealth;
        transform.rotation = Quaternion.identity;
    }

    protected virtual void Update()
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
            GameScene gameScene = Managers.Scene.CurrentScene as GameScene;
            gameScene.Score = 200;
            int ran = Random.Range(0, 11);
            GameObject go = null;
            if(ran < 3)
            {
                go = Managers.Resource.Instantiate("Item/Item Coin");
            }
            else if (ran < 5)
            {
                go = Managers.Resource.Instantiate("Item/Item Heal");
            }
            else if (ran < 7)
            {
                go = Managers.Resource.Instantiate("Item/Item Movement");
            }
            else if (ran < 9)
            {
                go = Managers.Resource.Instantiate("Item/Item Boom");
            }
            else if (ran < 11)
            {
                go = Managers.Resource.Instantiate("Item/Item Power");
            }
            if (go != null)
                go.transform.position = this.transform.position;
            Destroy(gameObject);
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerLimit")
        {
            Managers.Resource.Destroy(this.gameObject);
        }
        else if (collision.gameObject.tag == "Bullet")
        {
            Bullet bullet = collision.gameObject.GetComponent<Bullet>();
            OnHit(bullet.dmg);
            Managers.Resource.Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == "Player")
        {
            CharacterStatsHandler statsHandler = collision.GetComponent<CharacterStatsHandler>();
            int curHealth = statsHandler.CurrentStat.maxHealth;
            (Managers.UI.SceneUI as UI_GameScene).UIHeartUpdate(curHealth, false);
            statsHandler.CurrentStat.maxHealth--;
            if (statsHandler.CurrentStat.maxHealth <= 0)
            {
                Managers.UI.ShowPopupUI<UI_GameOver>();
            }  
        }
    }
}
