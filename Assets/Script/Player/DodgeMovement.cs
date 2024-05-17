using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private DodgeController controller;
    private Rigidbody2D movementRigidbody;
    private CharacterStatsHandler characterStatsHandler;

    private Vector2 movementDirection = Vector2.zero;

    private void Awake() 
    {
        controller = GetComponent<DodgeController>();
        movementRigidbody = GetComponent<Rigidbody2D>();
        characterStatsHandler = GetComponent<CharacterStatsHandler>();

        controller.onMoveEvent += Move;
    }

    private void FixedUpdate() 
    {
        ApplMovement(movementDirection);
    }

    public void Move(Vector2 direction)
    {
        movementDirection = direction;
    }

    private void ApplMovement(Vector2 direction)
    {
        direction *= characterStatsHandler.CurrentStat.movementSpeed;

        movementRigidbody.velocity = direction;
    }

}
