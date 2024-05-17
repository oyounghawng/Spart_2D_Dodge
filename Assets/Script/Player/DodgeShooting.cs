using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DodgeShooting : MonoBehaviour
{
    private DodgeController controller;
    [SerializeField] private Transform projectileSpawnPosition;
    public GameObject Bullet;
    protected CharacterStatsHandler Stats { get; private set; }

    private void Awake() 
    {
        controller = GetComponent<DodgeController>();
        controller.onAttackEvent += OnAttack;
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

        Bullet.transform.position = projectileSpawnPosition.position;
        Managers.Resource.Instantiate("Bullet");
    }
}
