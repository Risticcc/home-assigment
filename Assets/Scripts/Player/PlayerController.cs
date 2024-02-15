using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed = 1.0f;
    [SerializeField] private ContactFilter2D movementFilter;
    [SerializeField] private float collisionOffset = 0.1f;
    [SerializeField] private Animator animator;
    

    public bool CanMove { get; private set; } = true;
    private Vector2 _moveInput;
    private List<RaycastHit2D> _castCollisions = new List<RaycastHit2D>();
    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _rb;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(_moveInput != Vector2.zero)
        {
            var success = TryMove(_moveInput);
            
            if(!success)
                success = TryMove(new Vector2(_moveInput.x, 0));
                
            if(!success)
                success = TryMove(new Vector2(0, _moveInput.y));
            
            animator.SetBool("IsMoving", success);
        }
        else
        {
            animator.SetBool("IsMoving", false);
        }
    }
    
    private bool TryMove(Vector2 direction)
    {
        if (direction != Vector2.zero)
        {

            int count = _rb.Cast(
                direction,
                movementFilter,
                _castCollisions,
                moveSpeed * Time.fixedDeltaTime + collisionOffset);

            if (count == 0)
            {
                _rb.MovePosition(_rb.position + direction * Time.fixedDeltaTime * moveSpeed);
                return true;
            }
        }

        return false;
    }
    
    public void LockMovement()
    {
        CanMove = false;
    }
    
    public void UnlockMovement()
    {
        CanMove= true;
    }
    
    public void OnMove(InputValue movementValue)
    {
        _moveInput = movementValue.Get<Vector2>();
    }
}
