using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Invoke("RestartGame", 10f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void RestartGame()
	{
		SceneManager.LoadScene(0);
	}



}
