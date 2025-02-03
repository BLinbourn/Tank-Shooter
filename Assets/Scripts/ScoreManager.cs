using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public Text ScoreText;
    public Text HighscoreText;

    public static int score = 0;
    int highscore = 0;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        highscore = PlayerPrefs.GetInt("highscore", 0);
        ScoreText.text = "Enemies Killed: " + score.ToString();
        HighscoreText.text = "Highscore: " + highscore.ToString();
    }

    public void AddScore()
    {
        score += 1;

        ScoreText.text = "Enemies Killed: " + score.ToString();

        if (highscore < score)
        {
            PlayerPrefs.SetInt("highscore", score);
        }

        Debug.Log(score);
    }
}
