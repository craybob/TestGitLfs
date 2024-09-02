using UnityEngine;
using Zenject;

public class Player: MonoBehaviour
{
    private MovementHandler _movementHandler;

    
    [SerializeField] private float _jumpForce = 1f;
    [SerializeField] private float _speed = 5f;
    [SerializeField] private AnimationClip _jumpAnimClip;
    

    [Inject]
    private void Construct(MovementHandler movementHandler)
    {
        _movementHandler = movementHandler;
    }

    private void Start()
    {
        _movementHandler.rb = GetComponent<Rigidbody>();
        _movementHandler.animator = GetComponent<Animator>();

        _movementHandler.transformObj = transform;
        _movementHandler.speed = _speed;
        _movementHandler.jumpForce = _jumpForce;
        _movementHandler.jumpAnimClip = _jumpAnimClip;
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

    public void RbJumpMethod()
    {
        _movementHandler.PhysJump();
    }
}
