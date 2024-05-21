using System.Collections.Generic;
using UnityEngine;

public class CharacterStatsHandler : MonoBehaviour
{
    [SerializeField] private CharacterStat baseStat;
    public CharacterStat BaseStat
    {
        get { return baseStat; }
        private set { }
    }
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
        BulletSO _bulletSO = baseStat.bulletSO;
        CurrentStat = new CharacterStat
        {
            Level = baseStat.Level,
            bulletSO = _bulletSO,
            statsChangeType = baseStat.statsChangeType,
            maxHealth = baseStat.maxHealth,
            movementSpeed = baseStat.movementSpeed
        };

        //ApplyModifiers();
    }

    private void ApplyModifiers()
    {
        foreach (var modifier in statModifiers)
        {
            if (modifier.bulletSO != null)
            {/*
                if (CurrentStat.bulletSO == null)
                {
                    CurrentStat.bulletSO = Instantiate(modifier.attackSO);
                }
                else
                {
                    CurrentStat.bulletSO.delay += modifier.bulletSO.delay;
                    CurrentStat.bulletSO.power += modifier.bulletSO.power;
                    CurrentStat.bulletSO.speed += modifier.bulletSO.speed;
                }
                */
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
}
