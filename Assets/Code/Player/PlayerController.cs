using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterMovement2D))]
public class PlayerController : MonoBehaviour
{
    private CharacterMovement2D _characterMovement;
    private Vector2 _moveInput;

    private void Awake()
    {
        _characterMovement = GetComponent<CharacterMovement2D>();
    }

    public void OnMove(InputValue value)
    {
        _moveInput = value.Get<Vector2>();
    }

    private void Update()
    {
        _characterMovement.SetMoveInput(_moveInput);
    }
}
