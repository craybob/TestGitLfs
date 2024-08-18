using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class MovementHandler 
{
    public float speed;
    public Transform transformObj;

    
    public void Move(){
        Vector3 moveDirection = GetMoveDirection();
        transformObj.Translate(moveDirection , Space.World);
        Debug.Log("is Working");
    }
    
    private Vector3 GetMoveDirection(){
        float xDirertion = Input.GetAxis("Horizontal");
        float zDirection = Input.GetAxis("Vertical");
        Vector3 moveDirection = new Vector3(xDirertion * speed, 0f, zDirection * speed);

        return moveDirection;
    }
}
