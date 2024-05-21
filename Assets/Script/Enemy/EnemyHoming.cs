using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHoming : Enemy
{
    public float moveSpeed = 0.0f;
    private GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    private new void Update()
    {
        if (player != null)
        {
            Vector3 direction = (player.transform.position - transform.position).normalized;

            transform.position += direction * moveSpeed * Time.deltaTime;
        }
        if (transform.position.y < -6f)
        {
            Managers.Resource.Destroy(gameObject);
        }
    }
    //private new void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.CompareTag("Bullet"))
    //    {
    //        Destroy(gameObject);
    //    }
    //}
    public void SetInfo(GameObject go)
    {
        player = go;
    }
}