using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyBoss : Enemy
{
    public int patternIndex;
    public int curPatternCount;
    public int[] maxPatternCount;

    public float curShotDelay;
    public float maxShotDelay;
    private bool isThinking = false; // Added field

    protected override void Awake()
    {
        base.Awake();
        Maxhealth = 200;
        health = Maxhealth;
        speed = 2f;
        rigid.velocity = Vector2.down * speed;
    }

    //void OnEnable()
    //{
    //    health = Maxhealth;
    //}

    protected override void Update()
    {
        if (transform.position.y <= 6f)
        {
            Stop();
        }
    }

    void Stop()
    {
        if (!gameObject.activeSelf || isThinking) 
            return;

        Rigidbody2D rigid = GetComponent<Rigidbody2D>();
        rigid.velocity = Vector2.zero;
        isThinking = true; // Set the flag
        Invoke("Think", 2);
    }

    void Think()
    {
        patternIndex = patternIndex == 1 ? 0 : patternIndex + 1;
        curPatternCount = 0;
        switch (patternIndex)
        {
            case 0:
                FireBullet();
                break;
            case 1:
                FireShot();
                break;
        }
    }


    void FireBullet()
    {
        GameObject bullet = Managers.Resource.Instantiate("Enemy/BulletEnemyA", this.transform);
        bullet.transform.position = transform.position;
        bullet.transform.rotation = Quaternion.identity;

        Rigidbody2D rigid = bullet.GetComponent<Rigidbody2D>();
        Vector2 dirVec = new Vector2(Mathf.Sin(Mathf.PI * 10 * curPatternCount / maxPatternCount[patternIndex]), -1);
        rigid.AddForce(dirVec.normalized * 5, ForceMode2D.Impulse);

        curPatternCount++;
        if (curPatternCount < maxPatternCount[patternIndex])
            Invoke("FireBullet", 0.1f);
        else
            Invoke("Think", 2f);
    }
    void FireShot()
    {
        int roundNumA = 50;
        int roundNumB = 40;
        int roundNum = curPatternCount % 2 == 0 ? roundNumA : roundNumB;

        for (int index = 0; index < roundNum; index++)
        {
            GameObject bullet = Managers.Resource.Instantiate("Enemy/BulletEnemyB", this.transform);
            bullet.transform.position = transform.position;
            bullet.transform.rotation = Quaternion.identity;

            Rigidbody2D rigid = bullet.GetComponent<Rigidbody2D>();
            Vector2 dirVec = new Vector2(Mathf.Cos(Mathf.PI * 2 * index / roundNum),
                                            Mathf.Sin(Mathf.PI * 2 * index / roundNum));

            rigid.AddForce(dirVec.normalized * 2, ForceMode2D.Impulse);

            Vector3 rotVec = Vector3.forward * 360 * index / roundNum + Vector3.forward * 90;
            bullet.transform.Rotate(rotVec);
        }

        curPatternCount++;
        if (curPatternCount < maxPatternCount[patternIndex])
            Invoke("FireShot", 1f);
        else
            Invoke("Think", 2f);
    }


    void Reload()
    {
        curShotDelay += Time.deltaTime;
    }
}