using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DodgeAnimation : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    private void Awake()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }
    public void SetImage(Sprite _sprite)
    {
        spriteRenderer.sprite = _sprite;
    }
}
