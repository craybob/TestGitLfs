using System.Collections.Generic;
using UnityEngine;

public class MovementHandler 
{
    public float speed;
    public Transform transformObj;

    public Rigidbody rb;
    public float jumpForce = 5f;
    public bool onGround = true;

    public Animator animator;

    public AnimationClip jumpAnimClip;
    
    public void Move(){
        

        Vector3 moveDirection = GetMoveDirection();
        bool isMove = moveDirection == Vector3.zero ? false : true;
        animator.SetBool("Move", isMove);

        if(isMove)
            transformObj.Translate(moveDirection * speed * Time.deltaTime , Space.World);
    }
    public void Jump()
    {
        bool jump = (Input.GetAxis("Jump") != 0) ? true : false;

        if (jump)
        {
            PauseAnimationOfJump(1.05f);
        }
    }
    public void PhysJump()
    {
        Debug.Log("realJump");
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    private void PauseAnimationOfJump(float pauseTime)
    {
        float animationLengthInMilliseconds = jumpAnimClip.length * 1000;
        
        // –ассчитываем normalizedTime
        float normalizedTime = pauseTime / animationLengthInMilliseconds;

        // ”станавливаем анимацию в нужное место и приостанавливаем ее
        animator.Play(jumpAnimClip.name, -1, normalizedTime);
    }

    public void ResumeJumpAnim()
    {
        animator.Play(jumpAnimClip.name);
    }


    private Vector3 GetMoveDirection(){
        float xDirertion = Input.GetAxis("Horizontal");
        float zDirection = Input.GetAxis("Vertical");
        Vector3 moveDirection = GetCamRotation(zDirection, xDirertion);

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
