using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Itemype
{
    Boom,
    Coin,
    Power
}

public class Item : MonoBehaviour
{
    public Itemype type;
    Rigidbody2D rigid;

    public void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        rigid.velocity = Vector2.down * 3;
    }
}
