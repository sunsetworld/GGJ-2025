using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Range(1f, 10f)] public float moveSpeed = 5;
    Rigidbody2D rb2d;
    GameManager gameManager;
    public bool moveLeft;
    [SerializeField, Range(0.01f, 1f)] private float playerOxygenReductionAmount = 0.2f;
    private bool canDestroyKitten = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!moveLeft) rb2d.linearVelocity = Vector2.right * moveSpeed;
        else rb2d.linearVelocity = Vector2.left * moveSpeed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Kitten") && canDestroyKitten)
        {
            canDestroyKitten = false;
            Destroy(other.gameObject);
            gameManager.kittenAmount--;
            gameManager.currentKittens--;
            Destroy(this.gameObject);
        }
        else if (other.gameObject.CompareTag("Player"))
        {
            canDestroyKitten = false;
            PlayerOxygen playerOxygen = other.GetComponent<PlayerOxygen>();
            playerOxygen.oxygen -= playerOxygen.oxygenMax * playerOxygenReductionAmount;
            Destroy(this.gameObject);
        }
        else if (other.gameObject.CompareTag("Walls")) Destroy(this.gameObject);
    }
}
