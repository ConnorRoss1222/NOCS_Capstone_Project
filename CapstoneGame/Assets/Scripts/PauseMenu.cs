using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUi;

    // Update is called once per frame
    void Update()
    {
        //If the escape key is pressed;
        if ( Input.GetKeyDown( KeyCode.Escape ) )
        {
            //then resume
            if ( GameIsPaused )
            {
                Resume();
            }
            //then pause
            else
            {
                Pause();
            }
        }
    }

    //Resuming the Game Scene
    void Resume()
    {
        pauseMenuUi.SetActive( false );
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    //Pausing the game Scene
    void Pause()
    {
        pauseMenuUi.SetActive( true );
        Time.timeScale = 0f;
        GameIsPaused = true;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
    }

    //going back to the Menu screen from the pause menu
    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene( "Main Menu" );
    }

    //Making the Menu button Quit the Game
    public void QuitGame()
    {
        Application.Quit();
    }

    public void ResumeGame()
    {
        pauseMenuUi.SetActive( false );
        Time.timeScale = 1f;
        GameIsPaused = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
