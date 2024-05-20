using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public float dmg;
    private Vector2 direction;

    private void Update()
    {
        this.transform.Translate(Vector3.up * this.speed * Time.deltaTime);
        if(this.transform.position.y >20)
        {
            Managers.Resource.Destroy(this.gameObject);
        }
    }
    private void OnEnable()
    {
        
    }

    public void SetDirection(Vector2 direction)
    {
        this.direction = direction;
    }

    public void SetSo(CharacterStatsHandler stathandler)
    {
        dmg = stathandler.CurrentStat.attackSO.power;
    }
}
