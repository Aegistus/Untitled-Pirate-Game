using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameMenuControl : MonoBehaviour
{
    public static bool isPaused = false;
    public GameObject pauseOverlay;
    public GameObject pauseInfoOverlay;
    [SerializeField] private float timeSpeed = 0f;   //game speed when paused

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
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) )
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    void Pause()
    {
        sound.PlaySoundGlobal(menuSoundID);
        pauseOverlay.SetActive(true);
        Time.timeScale = timeSpeed;
        isPaused = true;
    }

    public void Resume() //unpause
    {
        sound.PlaySoundGlobal(leaveMenuSoundID);
        pauseOverlay.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void Restart() //restart game
    {
        isPaused = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene(2);
    }
    
    public void Quit() //quit to main menu
    {
        isPaused = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
    }

    public void Options() //in-detail info screen
    {
        sound.PlaySoundGlobal(menuSoundID);
        pauseOverlay.SetActive(false);
        pauseInfoOverlay.SetActive(true);
    }

    public void Return() //in-detail info screen
    {
        sound.PlaySoundGlobal(leaveMenuSoundID);
        pauseInfoOverlay.SetActive(false);
        pauseOverlay.SetActive(true);
    }
}
