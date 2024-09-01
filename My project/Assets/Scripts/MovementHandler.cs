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
        Vector3 moveDirection = GetCamRotation(zDirection, xDirertion);//new Vector3(xDirertion * speed, 0f, zDirection * speed);

        return moveDirection;
    }

    private Vector3 GetCamRotation(float directionZ, float directionX)
    {
        // --- Character rotation --- 

        Vector3 forward = Camera.main.transform.forward;
        Vector3 right = Camera.main.transform.right;

        forward.y = 0;
        right.y = 0;

        forward.Normalize();
        right.Normalize();

        // Relate the front with the Z direction (depth) and right with X (lateral movement)
        forward = forward * directionZ;
        right = right * directionX;

        if (directionX != 0 || directionZ != 0)
        {
            float angle = Mathf.Atan2(forward.x + right.x, forward.z + right.z) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.Euler(0, angle, 0);
            transformObj.rotation = Quaternion.Slerp(transformObj.rotation, rotation, 0.15f);
        }

        // --- End rotation ---
        

        //Vector3 verticalDirection = Vector3.up * Physics.gravity.y;
        Vector3 horizontalDirection = forward + right;

        Vector3 moviment =  horizontalDirection;

        return moviment;
    }
}
