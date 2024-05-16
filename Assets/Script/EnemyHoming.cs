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
    public GameObject player;  // �÷��̾� ������Ʈ ����

    private void Start()
    {
        if (player == null)
        {
            player = GameObject.FindWithTag("Player");  // �÷��̾ �±׷� ã��
        }
    }

    private void Update()
    {
        if (player != null)
        {
            Vector3 direction = (player.transform.position - transform.position).normalized;  // �÷��̾ ���ϴ� ����
            moveDirection = direction;
        }

        transform.position += moveDirection * moveSpeed * Time.deltaTime;

    }

    public void moveTo(Vector3 direction)
    {
        moveDirection = direction;
    }
}