using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int dmg;
    public float speed = 15.0f;
    private AttackSO AttackSO;
    private void Update()
    {
        this.transform.Translate(Vector3.up * this.speed * Time.deltaTime);    
    }

    public void SetSo(AttackSO So)
    {
        AttackSO = So;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "BorderBullet")
        {
            Destroy(gameObject);
        }
    }
}
