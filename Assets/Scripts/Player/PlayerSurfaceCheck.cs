using UnityEngine;

public class PlayerSurfaceCheck : MonoBehaviour
{
    PlayerMovement movement;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        movement = GetComponentInParent<PlayerMovement>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        movement.onSurface = false;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        movement.onSurface = true;
    }
}
