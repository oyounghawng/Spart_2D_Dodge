using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHoming : Enemy
{
    public float speed;
    public int health;
    public Sprite[] sprites;

    SpriteRenderer spriteRenderer;
    Rigidbody2D rigid;

    private float moveSpeed = 0.0f;
    private Vector3 moveDirection = Vector3.zero;
    private GameObject player;  // �÷��̾� ������Ʈ ����

    private void Start()
    {
        moveSpeed = 2.0f;
    }
    /*
    private void Update()
    {
        if (player != null)
        {
            Vector3 direction = (player.transform.position - transform.position).normalized;  // �÷��̾ ���ϴ� ����
            moveDirection = direction;
        }

        transform.position += moveDirection * moveSpeed * Time.deltaTime;

    }
    */
    public void SetInfo(GameObject go)
    {
        player = go;
    }

    public void moveTo(Vector3 direction)
    {
        moveDirection = direction;
    }
}