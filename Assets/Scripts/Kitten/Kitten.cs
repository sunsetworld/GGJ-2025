using System;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class Kitten : MonoBehaviour
{
    [Range(1f, 100f)]public float distanceFromPlayerMin = 1f;
    private bool isFollowingPlayer;
    Transform player;
    private Rigidbody2D rb2d;
    GameManager gameManager;
    [SerializeField] private float2 distanceRandomiser;
    [SerializeField] private AudioClip scoreSound;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        FollowPlayer();
    }

    void FollowPlayer()
    {
        if (!isFollowingPlayer) return;
        float distance = Vector3.Distance(player.position, rb2d.position);
        if (distance <= distanceFromPlayerMin) return;
        // transform.position = Vector3.MoveTowards(transform.position, player.position, distance * Time.deltaTime);
        float newRandomiser = Random.Range(distanceRandomiser.x, distanceRandomiser.y);
        rb2d.linearVelocity = player.position - transform.position;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.gameObject.name);
        if (other.gameObject.CompareTag("Player") && !isFollowingPlayer)
        {
            isFollowingPlayer = true;
            player = other.transform;
            gameManager.currentKittens++;
        }

        if (other.gameObject.CompareTag("KittenDetection"))
        {
            gameManager.kittenAmount--;
            gameManager.playerScore++;
            gameManager.currentKittens--;
            AudioSource.PlayClipAtPoint(scoreSound, transform.position);
            Debug.Log("Score: " + gameManager.playerScore);
            Destroy(this.gameObject);
        }
    }
}
