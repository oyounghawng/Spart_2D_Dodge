using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMob : MonoBehaviour
{
    public float moveSpeed = 0.0f;
    public Vector3 moveDirection = Vector3.down;

    private void Update()
    {
        transform.position += moveDirection * moveSpeed * Time.deltaTime;

        if (transform.position.y < -6f)
        {
            Destroy(gameObject);
        }
    }
    public void moveTo(Vector3 direction)
    {
        moveDirection = direction;
    }

}