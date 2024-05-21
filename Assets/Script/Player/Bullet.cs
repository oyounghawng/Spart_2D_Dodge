using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.iOS;
using UnityEngine.InputSystem.Layouts;

public class Bullet : MonoBehaviour
{
    private CharacterStat characterStat;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rigid;
    int level = 0;
    private void Awake()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        rigid = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        rigid.velocity = Vector3.up * (characterStat.bulletSO.speed[level]* Time.deltaTime);
        
        if (this.transform.position.y > 20)
        {
            Managers.Resource.Destroy(this.gameObject);
        }

    }
    private void OnEnable()
    {
        if (characterStat == null)
            return;
        transform.rotation = Quaternion.identity;
        level = characterStat.Level;
        spriteRenderer.sprite = characterStat.bulletSO.bulletSprite[level];
    }

    public void SetSo(CharacterStat _characterStat)
    {
        characterStat = _characterStat;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerLimit"))
        {
            Managers.Resource.Destroy(this.gameObject);
        }
    }
}
