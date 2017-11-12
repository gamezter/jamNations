using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public AudioClip clickSound;
	public AudioSource myAudioSource;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("1start"))
		{
			myAudioSource.clip = clickSound;
			myAudioSource.Play();
			Invoke("LoadGameScene", 1f);
		}
	}

	void LoadGameScene()
	{

		SceneManager.LoadScene(1);
	}


}
