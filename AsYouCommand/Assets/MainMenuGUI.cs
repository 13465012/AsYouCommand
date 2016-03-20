using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenuGUI : MonoBehaviour {

	public void PlayGame()
    {
        SceneManager.LoadScene("game");
    }

    public void Instructions()
    {
        SceneManager.LoadScene("Instructions");
    }

    public void HighScores()
    {
        SceneManager.LoadScene("HighScore");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
