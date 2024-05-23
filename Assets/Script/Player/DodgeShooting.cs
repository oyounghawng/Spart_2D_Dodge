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
        Stats = GetComponent<CharacterStatsHandler>();
        controller = GetComponent<DodgeController>();
        controller.onAttackEvent += OnAttack;
        projectileSpawnPosition = GetComponentsInChildren<Transform>()[2];
    }

    private void OnAttack(AttackSO attackSO)
    {
        if (attackSO == null) return;
        CreateProjectile();
    }

    private void CreateProjectile()
    {
        GameObject go = Managers.Resource.Instantiate("Bullet");
        go.transform.position = projectileSpawnPosition.position;
        go.transform.SetParent(projectileSpawnPosition);
        go.GetComponent<Bullet>().SetSo(Stats.CurrentStat);
        Managers.Sound.Play(Define.Sound.Effect, "Effect/Shoot" ,0.4f);
    }
}