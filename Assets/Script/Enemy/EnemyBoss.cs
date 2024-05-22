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

    private new void Update()
    {
        curShotDelay += Time.deltaTime;

        if (curShotDelay >= maxShotDelay)
        {
            Fire();
            curShotDelay = 0;
        }

        if (transform.position.y <= 6f)
        {
            Stop();
        }
    }

    private void Stop()
    {
        if (!gameObject.activeSelf)
            return;

        Rigidbody2D rigid = GetComponent<Rigidbody2D>();
        rigid.velocity = Vector2.zero;
    }

    void Think()
    {
        patternIndex = (patternIndex + 1) % 2;
        curPatternCount = 0;
        curShotDelay = 0;  

        switch (patternIndex)
        {
            case 0:
                Invoke("FireShot", maxShotDelay);
                break;
            case 1:
                Invoke("FireBullet", maxShotDelay); 
                break;
        }
    }

    void Fire()
    {
        if (curShotDelay < maxShotDelay)
            return;

        switch (patternIndex)
        {
            case 0:
                FireShot();
                break;
            case 1:
                FireBullet();
                break;
        }
    }

    void FireShot()
    {
        int roundNumA = 39;
        for (int index = 0; index < roundNumA; index++)
        {
            GameObject bullet = Managers.Resource.Instantiate("Enemy/BulletEnemyA", this.transform);
            bullet.transform.position = transform.position;
            bullet.transform.rotation = Quaternion.identity;

            Rigidbody2D rigid = bullet.GetComponent<Rigidbody2D>();
            Vector2 dirVec = new Vector2(Mathf.Sin(Mathf.PI * 2 * index / roundNumA), Mathf.Cos(Mathf.PI * 2 * index / roundNumA));
            rigid.AddForce(dirVec.normalized * 3, ForceMode2D.Impulse);
        }

        curPatternCount++;
        curShotDelay = 0; 
        if (curPatternCount < maxPatternCount[patternIndex])
            Invoke("FireShot", maxShotDelay);  
        else
            Invoke("Think", 3f);
    }

    void FireBullet()
    {
        GameObject bullet = Managers.Resource.Instantiate("Enemy/BulletEnemyB");
        bullet.transform.position = transform.position;
        bullet.transform.rotation = Quaternion.identity;

        Rigidbody2D rigid = bullet.GetComponent<Rigidbody2D>();
        Vector2 dirVec = new Vector2(Mathf.Sin((float)curPatternCount / maxPatternCount[patternIndex]), -1);
        rigid.AddForce(dirVec.normalized * 5, ForceMode2D.Impulse);

        curPatternCount++;
        curShotDelay = 0;  
        if (curPatternCount < maxPatternCount[patternIndex])
            Invoke("FireBullet", 1f);  
        else
            Invoke("Think", 5f);  
    }

    void Reload()
    {
        curShotDelay += Time.deltaTime;
    }
}