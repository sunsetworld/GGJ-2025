using UnityEngine;

public class Bubble : MonoBehaviour
{
    [SerializeField, Range(1, 10)] private float bubbleSpeed = 5f;
    Rigidbody2D rb2d;
    [SerializeField] private bool fillOxygenCompletely;
    [SerializeField, Range(0.1f, 1f)] private float fillOxygenAmount = 0.5f;
    [SerializeField] AudioClip collectSound;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb2d.linearVelocity = Vector2.up * bubbleSpeed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Kitten") || other.gameObject.CompareTag("Enemy")) return;
        if (other.CompareTag("Player"))
        {
            AudioSource.PlayClipAtPoint(collectSound, transform.position);
            PlayerOxygen oxygen = other.GetComponent<PlayerOxygen>();
            oxygen.IncreaseOxygen(fillOxygenCompletely, oxygen.oxygenMax * fillOxygenAmount);
        }
        if (!other.CompareTag("Ocean")) Destroy(this.gameObject);
    }
}
