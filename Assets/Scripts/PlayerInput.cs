using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    public Vector2 Move { get; private set; } = Vector2.zero;
    public bool IsAttacking { get; private set; } = false;

    private InputAction moveAction;
    private InputAction attackAction;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        attackAction = InputSystem.actions.FindAction("Attack");
        moveAction.performed += OnMove;
        moveAction.canceled += OnMove;
        attackAction.performed += OnAttack;
        attackAction.canceled += OnAttack;
    }

    void OnDestroy()
    {
        moveAction.performed -= OnMove;
        moveAction.canceled -= OnMove;
        attackAction.performed -= OnAttack;
        attackAction.canceled -= OnAttack;

    }

    private void OnMove(InputAction.CallbackContext context)
    {
        Move = context.ReadValue<Vector2>();
    }

    private void OnAttack(InputAction.CallbackContext context)
    {
        IsAttacking = context.performed;
    }
}
