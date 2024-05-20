using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DodgeController : MonoBehaviour
{
    public event Action<Vector2> onMoveEvent;
    public event Action<AttackSO> onAttackEvent;

    protected bool siAttacking { get; private set; }
    private float lastAttackTime = float.MaxValue;

    protected CharacterStatsHandler Stats { get; private set; }

    protected virtual void Awake() 
    {
        Stats = GetComponent<CharacterStatsHandler>();  
    }

    
    private void Update() 
    {
        HandleAttackDelay();
    }

    private void HandleAttackDelay()
    {
        if (lastAttackTime < Stats.CurrentStat.attackSO.delay)
        {
            lastAttackTime += Time.deltaTime;
        }
        else if(lastAttackTime >= Stats.CurrentStat.attackSO.delay)
        {
            lastAttackTime = 0f;
            CallAttackEvent(Stats.CurrentStat.attackSO);
        }
    }

    public void CallMoveEvent(Vector2 direction)
    {
        onMoveEvent?.Invoke(direction);
    }

    public void CallAttackEvent(AttackSO attackSO)
    {
        onAttackEvent?.Invoke(attackSO);
    }

}
