using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHoming : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 0.0f;
    [SerializeField]
    private Vector3 moveDirection = Vector3.zero;
    [SerializeField]
    public GameObject player;  // 플레이어 오브젝트 참조

    private void Start()
    {
        if (player == null)
        {
            player = GameObject.FindWithTag("Player");  // 플레이어를 태그로 찾기
        }
    }

    private void Update()
    {
        if (player != null)
        {
            Vector3 direction = (player.transform.position - transform.position).normalized;  // 플레이어를 향하는 방향
            moveDirection = direction;
        }

        transform.position += moveDirection * moveSpeed * Time.deltaTime;

    }

    public void moveTo(Vector3 direction)
    {
        moveDirection = direction;
    }
}