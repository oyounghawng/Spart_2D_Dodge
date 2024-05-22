using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMob : Enemy
{
    Vector3 moveDirection = Vector3.down;

    private void Start()
    {
        rigid.velocity = Vector2.down * speed;
    }
    private void OnEnable()
    {
        rigid.velocity = Vector2.down * speed;

    }
    public void moveTo(Vector3 direction)
    {
        moveDirection = direction;
    }
}