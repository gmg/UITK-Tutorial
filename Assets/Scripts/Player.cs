using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 8.0f;

    private Rigidbody2D _rb2d;
    private Vector2 _moveInput;

    private void Awake()
    {
        _rb2d = GetComponent<Rigidbody2D>();
    }

    private void OnMove(InputValue input)
    {
        _moveInput = input.Get<Vector2>();
    }

    private void FixedUpdate()
    {
        _rb2d.linearVelocity = _moveInput * moveSpeed;
    }
}
