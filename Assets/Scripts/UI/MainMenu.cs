using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{

    //Variables
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject gameUI;
    [SerializeField] private GameObject gameMenu;
    [SerializeField] private Text highscore;
    private bool paused;

    //Body

    void Start(){
        Scene currentScene = SceneManager.GetActiveScene ();
        if(currentScene.name == "MainMenu"){
            highscore.text = PlayerPrefs.GetInt("MazeHighscore").ToString();
        }
    }

    //Ensure game isnt paused and begin the regular game.
    public void ToGame()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Maze");
    }

    //Ensure game isnt paused and begin the practice game.
    public void ToPractice()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Practice");
    }

    //Return to the main menu scene.
    public void ToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    //Freeze time and enable the pause menu.
    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        gameUI.SetActive(false);
        Time.timeScale = 0.0f;
        paused = true;
    }

    //Resume the game from the pause menu.
    public void Resume()
    {
        pauseMenu.SetActive(false);
        gameUI.SetActive(true);
        Time.timeScale = 1.0f;
        paused = false;
    }

    //Enable the game menu.
    //Disable the main menu.
    public void toGameMenu()
    {
        gameMenu.SetActive(true);
        gameUI.SetActive(false);
    }

    //Enable the main menu.
    //Disable the game menu.
    public void toMainMenu()
    {
        gameMenu.SetActive(false);
        gameUI.SetActive(true);
    }

    //Exit the application if in build.
    public void QuitGame()
    {
        Application.Quit();
    }

    //Check if the game is paused.
    public bool isPaused()
    {
        return paused;
    }

}
