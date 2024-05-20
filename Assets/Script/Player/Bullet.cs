using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    private AttackSO AttackSO;
    private Vector2 direction;
    private CharacterStat characterStat;

    private void Update()
    {
        this.transform.Translate(Vector3.up * this.speed * Time.deltaTime);
    }

    public void SetDirection(Vector2 direction)
    {
        this.direction = direction;
    }

    public void SetSo(AttackSO attackSO)
    {
        AttackSO = attackSO;
    }

}
