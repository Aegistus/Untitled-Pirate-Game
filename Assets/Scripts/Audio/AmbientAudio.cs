using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbientAudio : MonoBehaviour
{
    [SerializeField] string oceanAmbianceString = "Ambiance_Ocean";

    SoundManager sound;
    int oceanAmbianceID;

    void Start()
    {
        sound = SoundManager.Instance;
        oceanAmbianceID = sound.GetSoundID(oceanAmbianceString);
        Transform playerTransform = FindObjectOfType<PlayerController>().transform;
        sound.PlaySoundAtPosition(oceanAmbianceID, playerTransform.position, playerTransform);
    }
}