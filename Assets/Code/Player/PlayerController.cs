using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterMovement2D))]
[RequireComponent(typeof(Interactor))]
public class PlayerController : MonoBehaviour
{
    private CharacterMovement2D _characterMovement;
    private Vector2 _moveInput;
    private Interactor _interactor;
    
    public delegate void InputInventoryEvent();

    public UnityEvent OnInventoryInput;

    private void Awake()
    {
        _characterMovement = GetComponent<CharacterMovement2D>();
        _interactor = GetComponent<Interactor>();
    }

    public void OnMove(InputValue value)
    {
        _moveInput = value.Get<Vector2>();
    }

    public void OnInteract()
    {
        _interactor.TryInteract();
    }

    public void OnInventory()
    {
        OnInventoryInput.Invoke();
    }

    private void Update()
    {
        _characterMovement.SetMoveInput(_moveInput);
    }
}
