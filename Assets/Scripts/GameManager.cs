using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] private GameOverScreen GameOverScreen;

    public bool gameOver = false;

    private void Awake()
    {
        instance = this;
    }

    public void GameOver()
    {
        GameOverScreen.Setup(ScoreManager.score);
    }
}
