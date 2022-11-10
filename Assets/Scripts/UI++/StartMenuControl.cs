using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;


public class StartMenuControl : MonoBehaviour
{
    public GameObject startOverlay;
    public GameObject startInfoOverlay;

    public void Start()
    {
        FindObjectOfType<AudioManager>().Play("Menu");
        startOverlay.SetActive(true);
        startInfoOverlay.SetActive(false);
    }

    public void Play() //start game
    {
        SceneManager.LoadScene(2);
    }

    public void Instructions() //only controls so far
    {
        FindObjectOfType<AudioManager>().Play("Menu");
        startOverlay.SetActive(false);
        startInfoOverlay.SetActive(true);
    }

    public void Back() //back to start menu
    {
        FindObjectOfType<AudioManager>().Play("LeaveMenu");
        startInfoOverlay.SetActive(false);
        startOverlay.SetActive(true);
    }
}
