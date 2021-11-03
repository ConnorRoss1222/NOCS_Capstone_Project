using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio; 

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUi;
    public GameObject PlayerCamera;
    public GameObject textbox;

    public AudioMixer mixer;

    public void SetLevel(float sliderValue )
    {
        mixer.SetFloat( "MusicVolume", Mathf.Log10( sliderValue ) * 20 ); //represents the slider value to a db level
    }

    // Update is called once per frame
    void Update()
    {
        //If the escape key is pressed;
        if ( Input.GetKeyDown( KeyCode.Escape ) )
        {
            if (GameIsPaused)
            {
                Debug.Log("Game already paused");
            }
            else
            {
                if (textbox.activeSelf)
                {
                    Debug.Log("fdsafdsafasd");
                }
                else
                {
                    Pause();
                }
            }
            
           
            
        }


    }

    //Resuming the Game Scene
    void Resume()
    {
        pauseMenuUi.SetActive( false );
        Time.timeScale = 1f;
        GameIsPaused = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    //Pausing the game Scene
    void Pause()
    {
        pauseMenuUi.SetActive( true );
        Time.timeScale = 0f;
        GameIsPaused = true;
        Cursor.visible = true;
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
