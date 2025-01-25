using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game_HUD : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private TextMeshProUGUI kittensText;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI oxygenText;
    [SerializeField] private TextMeshProUGUI endGameScoreText;
    GameManager gameManager;
    PlayerOxygen playerOxygen;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        playerOxygen = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerOxygen>();
    }

    // Update is called once per frame
    void Update()
    {
        timerText.text = "TIMER\n" + gameManager.timer.ToString("F2");
        kittensText.text = "KITTENS\n" + gameManager.currentKittens;
        scoreText.text = "SCORE\n" + gameManager.playerScore;
        oxygenText.text = "OXYGEN\n" + playerOxygen.oxygen.ToString("F2");

        if (gameManager.hasGameEnded)
        {
            endGameScoreText.text = "YOU HAVE SCORED\n" + gameManager.playerScore;
        }
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
