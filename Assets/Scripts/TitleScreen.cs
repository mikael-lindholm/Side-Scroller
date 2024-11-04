using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
    private string firstSceneName = "Evening City";

    //Loads the first scene
    public void LoadScene()
    {
        SceneManager.LoadScene(firstSceneName);
    }

    //Quits game
    public void QuitGame()
    {
        Application.Quit();
    }
}
