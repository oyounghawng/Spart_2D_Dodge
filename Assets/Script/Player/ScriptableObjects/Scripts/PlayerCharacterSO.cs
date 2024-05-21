using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenuAttribute(fileName = "DefaultPlayerSO", menuName = "DodgeController/Player/Default", order = 0)]
public class PlayerCharacterSO : ScriptableObject
{
    public Sprite[] ActiveSprite;
    public Sprite[] DeActiveSprites;
    public float MaxHP;
}
