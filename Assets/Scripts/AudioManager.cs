using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
	public static AudioManager audioManager;
	
	public AudioSource music;
	public AudioClip[] musicClips;

    public AudioSource sfx;
	public AudioClip[] sfxClips;

	public static AudioManager Instance = null;

	// singleton, persist across scenes
	private void Awake()
	{
		DontDestroyOnLoad(gameObject);
		audioManager = this;

		if (Instance == null)
		{
			Instance = this;
		} else if (Instance != this)
		{
			Destroy(gameObject);
		}
	}

    private void Update()
    {
		// in-game volume control
        if (Input.GetKeyDown(KeyCode.F4))
        {
			music.volume -= 0.1f;
			sfx.volume -= 0.1f;
		}
		if (Input.GetKeyDown(KeyCode.F5))
        {
			music.volume += 0.1f;
			sfx.volume += 0.1f;
		}
	}

    public void PlaySFX(AudioClip clip)
	{
		//randomize pitch for all of them .95-1.05

		//sfx[0].clip = clip;
		//sfx[0].Play();
	}

	public void PlayMusic(AudioClip clip)
	{
		// get scene name, play right music

		// gameplay
		music.clip = musicClips[0];
		music.Play();
	}
}
