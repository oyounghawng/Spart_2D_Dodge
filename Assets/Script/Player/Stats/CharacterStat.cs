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
    private int level = 0;
    public int Level
    {
        get
        {
            return level;
        }
        set
        {
            if (level >= 4)
            {
                level = 4;
            }
            else
                level = value;
        }
    }
    public int LevelUp
    {
        set
        {
            if (level >= 3)
                level = 3;
            else
                level += value;
        }
    }
    public StatsChangeType statsChangeType;
    [Range(1, 10)] public int maxHealth;
    [Range(1f, 20f)] public int movementSpeed;
    public BulletSO bulletSO;
}
