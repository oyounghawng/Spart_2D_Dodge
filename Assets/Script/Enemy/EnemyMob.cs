using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMob : Enemy
{
    private void Start()
    {
        speed = 6f;
        rigid.velocity = Vector2.down * speed;

    }
    private void OnEnable()
    {
        rigid.velocity = Vector2.down * speed;
        transform.rotation = Quaternion.identity;

    }
}