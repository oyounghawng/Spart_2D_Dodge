using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenuAttribute(fileName = "RangedAttackSO",menuName = "DodgeController/Attacks/Ranged", order = 1)]
public class RangedAttackSO : AttackSO
{
    [Header("Ranged Attack Info")]
    public string bulletNameTag;
    public float duration;
    public float spread;
    public int numberOfProjectilesPerShot;
    public float multipleProjectilesAngle;
    public Color projectileColor;
}