using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb2d;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    [SerializeField, Range(1, 100)] private float movementSpeed = 5f;

    public bool onSurface;

    public void OnMove(InputAction.CallbackContext context)
    {
        Vector2 velocity = context.ReadValue<Vector2>() * movementSpeed;
        if (onSurface) velocity.y = 0;
        rb2d.AddForce(velocity, ForceMode2D.Impulse);
    }
}
