using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class MovementHandler : ITickable, IInitializable
{
    public Transform player;
    public float speed;
    public void Initialize()
    {
        throw new System.NotImplementedException();
    }

    public void Tick()
    {
        
    }

    public void Move(){
        Vector3 moveDirection = GetMoveDirection();
        player.Translate(moveDirection , Space.World);
        Debug.Log("is Working");
    }
    
    private Vector3 GetMoveDirection(){
        float xDirertion = Input.GetAxis("Horizontal");
        float zDirection = Input.GetAxis("Vertical");
        Vector3 moveDirection = new Vector3(xDirertion * speed, 0f, zDirection * speed);

        return moveDirection;
    }
}
