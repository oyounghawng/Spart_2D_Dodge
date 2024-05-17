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

    private void Awake() 
    {
        controller = GetComponent<DodgeController>();
        controller.onAttackEvent += OnAttack;
        projectileSpawnPosition = GetComponentsInChildren<Transform>()[2];
        Bullet = Managers.Resource.Load<GameObject>("Prefabs/Bullet");
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
        // GameObject obj = Instantiate(Bullet);
        // obj.transform.position = projectileSpawnPosition.position;

        // ProjectileController attakController = obj.GetComponent<ProjectileController>();
        // attakController.InitializeAttack(rangedAttackSO);

        GameObject go = Managers.Resource.Instantiate(Bullet, projectileSpawnPosition);
        go.transform.position = projectileSpawnPosition.position;
        go.GetComponent<Bullet>().SetSo(rangedAttackSO);
    }
}
