using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;

public class Player: MonoBehaviour, ITickable, Zenject.IInitializable
{

    [Inject]
    private MovementHandler _movementHandler;

    [SerializeField] public GameObject anotherObj;

    //[Inject]
    //private void Construct(MovementHandler movementHandler){
    //    _movementHandler = movementHandler;
    //}

    private void Start()
    {
        _movementHandler.transformObj = transform;
        _movementHandler.speed = 5f;
    }
    public void Initialize(){
        

    }
    void ITickable.Tick()
    {
        //_movementHandler.Move();
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    _container.InstantiatePrefab(anotherObj);
        //}
    }
    private void Update()
    {
        _movementHandler.Move();
        //_movementHandler.Move();
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    _container.InstantiatePrefab(anotherObj);
        //}
    }

}
