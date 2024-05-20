using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHoming : Enemy
{
<<<<<<< HEAD
    public float speed;
    public int health;
    public Sprite[] sprites;

    SpriteRenderer spriteRenderer;
    Rigidbody2D rigid;

    private float moveSpeed = 0.0f;
    private Vector3 moveDirection = Vector3.zero;
    private GameObject player;  // 플레이어 오브젝트 참조
=======
    public float moveSpeed = 0.0f;
    public GameObject player;
>>>>>>> parent of ae0f449 (Revert "Merge branch 'JeongHun' into Oyoung")

    private void Awake()
    {
        player = Managers.Object.Player;
    }
    /*
    private void Update()
    {
        if (player != null)
        {
            Vector3 direction = (player.transform.position - transform.position).normalized;

            transform.position += direction * moveSpeed * Time.deltaTime;
        }
    }
<<<<<<< HEAD
    */
=======

>>>>>>> parent of ae0f449 (Revert "Merge branch 'JeongHun' into Oyoung")
    public void SetInfo(GameObject go)
    {
        player = go;
    }
}