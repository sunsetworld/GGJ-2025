using System;
using UnityEngine;

public class KittenDetection : MonoBehaviour
{
    GameManager gameManager;

    private void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }
}
