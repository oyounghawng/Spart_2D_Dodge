using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Layouts;

public class Bullet : MonoBehaviour
{
    public float speed;
    public float dmg;
    private Vector2 direction;

    private void Update()
    {
        this.transform.Translate(Vector3.up * this.speed * Time.deltaTime);
        if (this.transform.position.y > 20)
        {
            Managers.Resource.Destroy(this.gameObject);
        }
    }
    private void OnEnable()
    {
        transform.rotation = Quaternion.identity;
    }

    public void SetDirection(Vector2 direction)
    {
        this.direction = direction;
    }

    public void SetSo(CharacterStatsHandler stathandler)
    {
        dmg = stathandler.CurrentStat.attackSO.power;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerLimit"))
        {
            Managers.Resource.Destroy(this.gameObject);
        }
    }
}
