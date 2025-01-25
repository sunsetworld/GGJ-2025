using UnityEngine;

public class PlayerOxygen : MonoBehaviour
{
    public float oxygen = 100;
    [HideInInspector] public float oxygenMax;
    public float oxygenDepeletion = 1;
    PlayerMovement playerMovement;
    GameManager gameManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        oxygenMax = oxygen;
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerMovement.onSurface)
        {
            oxygen = oxygenMax;
            return;
        }
        if (!playerMovement.onSurface && oxygen > 0)
        {
            oxygen -= oxygenDepeletion * Time.deltaTime;
        }

        if (oxygen <= 0)
        {
            gameManager.GameOver(true);
        }
        Debug.Log("Oxygen: " + oxygen);
    }

    public void IncreaseOxygen(bool increaseToFull, float increaseAmount)
    {
        if (increaseToFull) oxygen = oxygenMax;
        else if (oxygen + increaseAmount > oxygenMax) oxygen = oxygenMax;
        else oxygen += increaseAmount;
    }
}
