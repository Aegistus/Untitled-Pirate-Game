using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameMenuControl : MonoBehaviour
{
    public static bool isPaused = false;
    public static bool shopping = false;
    public GameObject pauseOverlay;
    public GameObject pauseInfoOverlay;
    public GameObject shopOverlay;
    [SerializeField] private float pauseTime = 0f;   //game speed when paused
    [SerializeField] private float shopTime = 0f;   //game speed when shopping

    SoundManager sound;
    int menuSoundID;
    int leaveMenuSoundID;

    public void Start()
    {
        sound = SoundManager.Instance;
        menuSoundID = sound.GetSoundID("Menu");
        leaveMenuSoundID = sound.GetSoundID("LeaveMenu");
        pauseOverlay.SetActive(false);
        pauseInfoOverlay.SetActive(false);
        shopOverlay.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) )
        {
            if (isPaused)
            {
                Resume();
            }
            else if (!shopping)
            {
                Pause();
            }
        }

        if (Input.GetKeyDown(KeyCode.Tab) )
        {
            if (shopping)
            {
                Resume();
            }
            else if (!isPaused)
            {
                Shop();
            }
        }
    }

    void Pause()
    {
        sound.PlaySoundGlobal(menuSoundID);
        pauseOverlay.SetActive(true);
        Time.timeScale = pauseTime;
        isPaused = true;
    }

    public void Resume() //unpause
    {
        sound.PlaySoundGlobal(leaveMenuSoundID);
        pauseOverlay.SetActive(false);
        shopOverlay.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        shopping = false;
    }

    public void Restart() //restart game
    {
        isPaused = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
    }
    
    public void Quit() //quit to main menu
    {
        isPaused = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void Options() //to in-detail info screen
    {
        sound.PlaySoundGlobal(menuSoundID);
        pauseOverlay.SetActive(false);
        pauseInfoOverlay.SetActive(true);
    }

    public void Return() //from in-detail info screen
    {
        sound.PlaySoundGlobal(leaveMenuSoundID);
        pauseInfoOverlay.SetActive(false);
        pauseOverlay.SetActive(true);
    }

    public void Shop()
    {
        sound.PlaySoundGlobal(menuSoundID);
        shopOverlay.SetActive(true);
        Time.timeScale = shopTime;
        shopping = true;
    }
}
