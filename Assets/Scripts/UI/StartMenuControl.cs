using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class StartMenuControl : MonoBehaviour
{
    public GameObject startOverlay;
    public GameObject startInfoOverlay;

    //SoundManager sound;      //sound is throwing me errors so im throwing it out >:(
    //int menuSoundID;          //temporarily
    //int leaveMenuSoundID;

    public void Start()
    {
        //sound = SoundManager.Instance;
        //menuSoundID = sound.GetSoundID("Menu_Open");
        //leaveMenuSoundID = sound.GetSoundID("Menu_Close");
        startOverlay.SetActive(true);
        startInfoOverlay.SetActive(false);
    }

    public void Play() //start game
    {
        SceneManager.LoadScene(1);
    }

    public void Info() //only controls so far
    {
        //sound.PlaySoundGlobal(menuSoundID);
        startOverlay.SetActive(false);
        startInfoOverlay.SetActive(true);
    }

    public void Back() //back to start menu
    {
        //sound.PlaySoundGlobal(leaveMenuSoundID);
        startInfoOverlay.SetActive(false);
        startOverlay.SetActive(true);
    }
}
