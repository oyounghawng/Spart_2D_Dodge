using System.Collections.Generic;
using UnityEngine;

public class CharacterStatsHandler : MonoBehaviour
{
    [SerializeField] private CharacterStat baseStat;
    public CharacterStat CurrentStat { get; private set; }
    public DodgeController controller;

    public List<CharacterStat> statModifiers = new List<CharacterStat>();

    private void Awake() 
    {
        controller = GetComponent<DodgeController>();
        UpdateCharacterStat();
    }

    public void UpdateCharacterStat() 
    {
        AttackSO attackSO = null;

        if (baseStat.attackSO != null)
        {
            attackSO = Instantiate(baseStat.attackSO);
        }

        CurrentStat = new CharacterStat 
        {
            attackSO = attackSO,
            statsChangeType = baseStat.statsChangeType,
            maxHealth = baseStat.maxHealth,
            movementSpeed = baseStat.movementSpeed
        };

        ApplyModifiers();
    }

    private void ApplyModifiers()
    {
        foreach (var modifier in statModifiers)
        {
            if (modifier.attackSO != null)
            {
                if (CurrentStat.attackSO == null)
                {
                    CurrentStat.attackSO = Instantiate(modifier.attackSO);
                }
                else
                {
                    CurrentStat.attackSO.size += modifier.attackSO.size;
                    CurrentStat.attackSO.delay += modifier.attackSO.delay;
                    CurrentStat.attackSO.power += modifier.attackSO.power;
                    CurrentStat.attackSO.speed += modifier.attackSO.speed;
                }
            }

            CurrentStat.maxHealth += modifier.maxHealth;
            CurrentStat.movementSpeed += modifier.movementSpeed;
        }
    }

    public void AddModifier(CharacterStat modifier)
    {
        statModifiers.Add(modifier);
        UpdateCharacterStat();
    }

    public void RemoveModifier(CharacterStat modifier)
    {
        statModifiers.Remove(modifier);
        UpdateCharacterStat();
    }

    [ContextMenu("Asd")]
    public void Test()
    {
        CharacterStat addStat = new CharacterStat();
        addStat.movementSpeed = 5;
        AddModifier(addStat);
    }
}
