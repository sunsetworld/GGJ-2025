using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int playerScore;
    public bool hasGameEnded = false;
    private GameObject player;
    Rigidbody2D playerRb;
    private GameObject[] kittens;
    public int currentKittens;
    public int kittenAmount;
    [SerializeField, Range(0, 300)] public float timer;

    public bool hasGameStarted;

    [SerializeField] private GameObject hud;
    [SerializeField] GameObject gameOverScreen;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerRb = player.GetComponent<Rigidbody2D>();
        GetCurrentKittens();
        kittenAmount = kittens.Length;
    }

    // Update is called once per frame
    void Update()
    {
        if (kittenAmount == 0) GameOver(false);
        Timer();
    }

    private void Timer()
    {
        if (!hasGameStarted) return;
        if (hasGameEnded) return;
        switch (timer)
        {
            case > 0:
                timer -= Time.deltaTime;
                break;
            case <= 0:
                GameOver(false);
                break;
        }
    }

    public void GameOver(bool hasPlayerDied)
    {
        if (hasGameEnded) return;
        hasGameEnded = true;
        if (hasPlayerDied)
        {
            playerRb.gravityScale = 1f;
        }
        playerRb.linearVelocity = Vector2.zero;
        DestroyRemainingKittens();
        hud.SetActive(false);
        gameOverScreen.SetActive(true);
    }

    private void DestroyRemainingKittens()
    {
        GetCurrentKittens();
        foreach (var kitten in kittens) Destroy(kitten);
    }

    void GetCurrentKittens()
    {
        kittens = GameObject.FindGameObjectsWithTag("Kitten");
    }
}
