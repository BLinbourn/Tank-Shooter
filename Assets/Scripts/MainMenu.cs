using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    public Button startButton;
    public Button optionsButton;
    public Button quitButton;

    public void PlayGame ()
    {
        SceneManager.LoadScene("Tank-Shooter");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void StartButtonHooverOn()
    {
        startButton.image.color = new Color(0.25f, 0.31f, 0.45f);
    }

    public void StartButtonHooverOff()
    {
        startButton.image.color = new Color(0.15f, 0.26f, 0.23f);
    }

    public void OptionsButtonHooverOn()
    {
        optionsButton.image.color = new Color(0.25f, 0.31f, 0.45f);
    }

    public void OptionsButtonHooverOff()
    {
        optionsButton.image.color = new Color(0.15f, 0.26f, 0.23f);
    }

    public void ExitButtonHooverOn()
    {
        quitButton.image.color = new Color(0.25f, 0.31f, 0.45f);
    }

    public void ExitButtonHooverOff()
    {
        quitButton.image.color = new Color(0.15f, 0.26f, 0.23f);
    }
}