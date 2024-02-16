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
    

    public bool CanMove { get; private set; } = true;
    private Vector2 _moveInput;
    private List<RaycastHit2D> _castCollisions = new List<RaycastHit2D>();
    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _rb;
    private Animator _animator;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
       AnimatorSetUp();
    }

    public void AnimatorSetUp()
    {
        var child = FindActiveChild();
        if (child != null)
        {
            _animator = child.GetComponent<Animator>();
            if (_animator == null)
            {
                Debug.LogWarning("Active child object does not have an Animator component");
            }
        }
        
        
    }

    public GameObject FindActiveChild()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            var child = transform.GetChild(i);
            if (child.gameObject.activeSelf)
            {
                return child.gameObject;
            }
        }
        Debug.LogWarning("No active child object found");
        return null;
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
            
            _animator.SetBool("IsMoving", success);
        }
        else
        {
            _animator.SetBool("IsMoving", false);
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
