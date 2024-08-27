using UnityEngine;
using Zenject;

public class MovementHandler 
{
    public float speed;
    public Transform transformObj;

    public Rigidbody rb;
    public float jumpForce = 5f;

    
    public void Move(){
        Vector3 moveDirection = GetMoveDirection();
        transformObj.Translate(moveDirection * Time.deltaTime , Space.World);
        Debug.Log("is Working");
    }
    public void Jump()
    {
        bool jump = (Input.GetAxis("Jump") != 0) ? true : false;

        if (jump)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
    
    private Vector3 GetMoveDirection(){
        float xDirertion = Input.GetAxis("Horizontal");
        float zDirection = Input.GetAxis("Vertical");
        Vector3 moveDirection = new Vector3(xDirertion * speed, 0f, zDirection * speed);

        return moveDirection;
    }
}
