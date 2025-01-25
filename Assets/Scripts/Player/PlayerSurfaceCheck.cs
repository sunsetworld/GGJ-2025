using UnityEngine;

public class PlayerSurfaceCheck : MonoBehaviour
{
    PlayerMovement movement;
    GameManager gameManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        movement = GetComponentInParent<PlayerMovement>();
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ocean"))
        {
            movement.onSurface = false;
            return;
        }
        if (!gameManager.hasGameStarted) gameManager.hasGameStarted = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Ocean")) movement.onSurface = true;
    }
}
