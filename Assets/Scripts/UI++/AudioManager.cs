using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
	public static AudioManager instance;

	public AudioMixerGroup mixerGroup;

	public Audio[] sounds;

	void Awake()
	{
		if (instance != null)
		{
			Destroy(gameObject);
			return;
		}
		else
		{
			instance = this;
			DontDestroyOnLoad(gameObject);
		}

		foreach (Audio s in sounds)
		{
			s.source = gameObject.AddComponent<AudioSource>();

			s.source.clip = s.clip;
			s.source.loop = s.loop;

			s.source.outputAudioMixerGroup = mixerGroup;
		}
	}

	public void Start()
	{
		Play("Background");
	}

	public void Play(string name)
	{
		Audio s = Array.Find(sounds, sound => sound.name == name);
		s.source.volume = s.volume * (1f + UnityEngine.Random.Range(-s.volumeVariance / 2f, s.volumeVariance / 2f));
		s.source.pitch = s.pitch * (1f + UnityEngine.Random.Range(-s.pitchVariance / 2f, s.pitchVariance / 2f));
		Debug.Log("Playing sound: " + s.name);

		if (GameMenuControl.isPaused)
		{
			//some line to adjust background and not button noises.  probably need to start background differently but it works for now
		}

		s.source.Play();
	}

}