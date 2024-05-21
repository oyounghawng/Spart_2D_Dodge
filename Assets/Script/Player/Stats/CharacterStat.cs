using UnityEngine;

public enum StatsChangeType
{
    Add,
    Multiple,
    Override
}

[System.Serializable]
public class CharacterStat
{
    public int Level;
    public StatsChangeType statsChangeType;
    [Range(1, 10)] public int maxHealth;
    [Range(1f, 20f)] public int movementSpeed;
    public BulletSO bulletSO; 
}
