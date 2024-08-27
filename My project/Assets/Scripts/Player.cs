using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;

public class Player: MonoBehaviour
{
    private MovementHandler _movementHandler;

    
    [SerializeField] public float _jumpForce = 1f;

    [Inject]
    private void Construct(MovementHandler movementHandler)
    {
        _movementHandler = movementHandler;
    }

    private void Start()
    {
        _movementHandler.rb = GetComponent<Rigidbody>();
        _movementHandler.transformObj = transform;
        _movementHandler.speed = 5f;
        _movementHandler.jumpForce = _jumpForce;
    }
    
    private void Update()
    {
        MoveMethods();
    }

    private void MoveMethods()
    {
        _movementHandler.Move();
        _movementHandler.Jump();
    }
}
