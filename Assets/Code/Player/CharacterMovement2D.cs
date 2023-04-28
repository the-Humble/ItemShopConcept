using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class CharacterMovement2D : MonoBehaviour
{
    [SerializeField] private float _speed = 1.0f;
    public Vector2 MoveInput { get; private set; }
    public float Speed { get; }
    public bool HasMoveInput { get; private set;  }

    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        _rigidbody.MovePosition((Vector2)transform.position + (MoveInput * (_speed * Time.deltaTime)));
    }

    public void SetMoveInput(Vector2 input)
    {
        input = Vector2.ClampMagnitude(input, 1.0f);

        HasMoveInput = input.magnitude > 0.1f;

        input = HasMoveInput ? input : Vector2.zero;

        MoveInput = input;
    }

}
