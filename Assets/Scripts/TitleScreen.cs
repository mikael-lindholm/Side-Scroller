using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
//Only necessary when playing in Unity editor
using UnityEditor;

public class TitleScreen : MonoBehaviour
{
    private string firstSceneName = "Small Town";

    //Loads the first scene
    public void LoadScene()
    {
        SceneManager.LoadScene(firstSceneName);
    }

    //Quits game
    public void QuitGame()
    {
        //For finalized app
        //Application.Quit();

        //For playing in Unity editor
        EditorApplication.ExitPlaymode();
    }
}
