using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb2d;
    [SerializeField, Range(1, 10)] private float movementSpeed = 5f;
    [SerializeField, Range(1, 5)] private float slowDownTime = 3f;
    GameManager gameManager;

    public bool onSurface;
    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        onSurface = true;
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        if (gameManager.hasGameEnded) return;
        Vector2 velocity = context.ReadValue<Vector2>() * movementSpeed;
        if (onSurface && velocity.y > 0) velocity.y = 0;
        rb2d.AddForce(velocity, ForceMode2D.Impulse);
    }
}
