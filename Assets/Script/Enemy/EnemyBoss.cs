using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoss : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 1.5f;
    [SerializeField]
    private Vector3 moveDirection = Vector3.down;


    private void Update()
    {
        if (transform.position.y > 7.4f)
        {
            transform.position = new Vector3(transform.position.x, 7.4f, transform.position.z);
        }
        else
        {
            transform.position += Vector3.down * moveSpeed * Time.deltaTime;
        }

            if (transform.position.y < -6f)
        {
            Destroy(gameObject);
        }
    }
}