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
    [SerializeField] public float _speed = 5f;

    [Inject]
    private void Construct(MovementHandler movementHandler)
    {
        _movementHandler = movementHandler;
    }

    private void Start()
    {
        _movementHandler.rb = GetComponent<Rigidbody>();
        _movementHandler.transformObj = transform;
        _movementHandler.speed = _speed;
        _movementHandler.jumpForce = _jumpForce;
    }
    
    private void Update()
    {
        MoveMethods();

        //if (Input.GetKeyDown(KeyCode.LeftArrow)) 
        //{
        //    Debug.Log(new Vector3(transform.position.x, transform.position.y, transform.position.z));
        //}
        //if (Input.GetKeyDown(KeyCode.RightArrow))
        //{
        //    Vector3 tot =  new Vector3(transform.position.x, transform.position.y, transform.position.z);
        //    tot.Normalize();
        //    Debug.Log(tot);
        //}
    }

    private void MoveMethods()
    {
        _movementHandler.Move();
        _movementHandler.Jump();
    }
}
