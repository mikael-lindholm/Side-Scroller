using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //Text fields
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI gameOverText;
    //Buttons
    [SerializeField] private Button tryAgain;
    [SerializeField] private Button quitGame;
    //Float variable for how much time has passed and int variable for the score
    private float timePassed = 0;
    private float score = 0;
    //Player Controller -script
    private PlayerController playerControllerScript;
    //Gets current gravity settings in order to fix a bug at LoadScene
    private Vector3 startGravity = Physics.gravity;

    void Start()
    {
        //Fetch the Player Controller -script from player character
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

   
    void Update()
    {
        ScoreManager();
        GameOver();
    }

    //Updates score based on the time that's passed from start of the game
    void ScoreManager()
    {
        if (playerControllerScript.gameOver == false)
        {
            timePassed += Time.deltaTime;
            score = Mathf.RoundToInt(timePassed);
            scoreText.text = "Score:" + score;
        }
    }

    //Game over screen
    void GameOver()
    {
        if (playerControllerScript.gameOver == true)
        {
            gameOverText.text = "Game Over";
            tryAgain.gameObject.SetActive(true);
            quitGame.gameObject.SetActive(true);
        }
    }

    //Loads a new scene
    public void LoadScene(string sceneName)
    {
        //Resets gravity in order to fix a bug that screws up jump height after loading a scene
        Physics.gravity = startGravity;
        //Loads the scene that's name was given as the function's argument
        SceneManager.LoadScene(sceneName);
    }

    //Quits the game
    public void QuitGame()
    {
        Application.Quit();
    }
}
