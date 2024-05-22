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
        BulletSO _bulletSO = baseStat.bulletSO;
        CurrentStat = new CharacterStat
        {
            Level = baseStat.Level,
            bulletSO = _bulletSO,
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

    public void AddLevelEffect()
    {
        if (baseStat.Level >= 3)
            return;

        baseStat.Level = 1;
        UpdateCharacterStat();
    }

    public void AddMovementEffect()
    {
        if (CurrentStat.movementSpeed >= 21)
            return;

        CharacterStat addStat = new CharacterStat
        {
            statsChangeType = StatsChangeType.Add,
            bulletSO = ScriptableObject.CreateInstance<BulletSO>()
        };

        addStat.movementSpeed = 2;

        AddModifier(addStat);

    }

    public void AddHealthEffect()
    {
        if (CurrentStat.maxHealth >= 8)
            return;

        CharacterStat addStat = new CharacterStat
        {
            statsChangeType = StatsChangeType.Add,
            bulletSO = ScriptableObject.CreateInstance<BulletSO>()
        };

        addStat.maxHealth = 1;
        AddModifier(addStat);
        (Managers.UI.SceneUI as UI_GameScene).UIHeartUpdate(CurrentStat.maxHealth, true);
    }
}
