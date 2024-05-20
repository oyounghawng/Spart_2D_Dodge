using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class DodgeShooting : MonoBehaviour
{
    private DodgeController controller;
    private Transform projectileSpawnPosition;
    private GameObject Bullet;
    protected CharacterStatsHandler Stats { get; private set; }
    private ObjectPool pool;

    private void Awake() 
    {
        controller = GetComponent<DodgeController>();
        controller.onAttackEvent += OnAttack;
        projectileSpawnPosition = GetComponentsInChildren<Transform>()[2];
        Bullet = Managers.Resource.Load<GameObject>("Prefabs/Bullet");
        pool = GameObject.FindObjectOfType<ObjectPool>();
    }

    private void OnAttack(AttackSO attackSO)
    {
        RangedAttackSO rangedAttackSO = attackSO as RangedAttackSO;
        if(rangedAttackSO == null) return;

        int numberOfProjectilesPerShot = rangedAttackSO.numberOfProjectilesPerShot;

        for (int i = 0; i < numberOfProjectilesPerShot; i++)
        {
            CreateProjectile(rangedAttackSO);
        }
    }

    private void CreateProjectile(RangedAttackSO rangedAttackSO)
    {
        GameObject go = pool.SpawnFromPool(rangedAttackSO.bulletNameTag);
        go.transform.SetParent(null, true);

        go.GetComponent<Bullet>().SetSo(rangedAttackSO);
    }
}
