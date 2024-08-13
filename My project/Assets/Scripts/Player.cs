using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;

public class Player: MonoBehaviour, ITickable
{
    private MovementHandler _movementHandler;

    [Inject]
    public void Construct(MovementHandler movementHandler){
        _movementHandler = movementHandler;
    }
    private void Start(){
        _movementHandler.player = transform;
        _movementHandler.speed = 15f;
    }
    private void Update(){
         _movementHandler.Move();
    }
    public void Tick()
    {
        _movementHandler.Move();
    }
}
