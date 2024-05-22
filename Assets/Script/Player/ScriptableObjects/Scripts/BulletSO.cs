using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenuAttribute(fileName = "BulletSO",menuName = "DodgeController/Attacks/Bullet", order = 1)]
public class BulletSO : AttackSO
{
    [Header("Bullet Info")]
    public Sprite[] bulletSprite;

    [Header("Flight Info")]
    public PlayerCharacterSO[] playerCharacterSO;
}