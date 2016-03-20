using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class InstructionsGUI : MonoBehaviour {

	public void MainMenuChange()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
