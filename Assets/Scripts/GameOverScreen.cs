using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{

    public Text pointsText;

    public void Setup(int score)
    {
        gameObject.SetActive(true);
        pointsText.text = "Enemies Killed: " + score.ToString();
    }

    public void RestartButton()
    {
        SceneManager.LoadScene("Tank-Shooter");
        ScoreManager.score = 0;
        GameManager.instance.gameOver = false;
    }

    public void ExitButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
