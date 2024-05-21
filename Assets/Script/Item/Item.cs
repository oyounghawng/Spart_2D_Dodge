using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Boom,
    Coin,
    Power
}
public class Item : MonoBehaviour
{
    public ItemType type;
    Rigidbody2D rigid;

    public void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        rigid.velocity = Vector2.down * 0.5f;
    }
}
