using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CreditMenu : MonoBehaviour {

	public Text theScore;
	private string texto;

	// Use this for initialization
	void Start () {
		Invoke("RestartGame", 10f);
		float tempF = PlayerPrefs.GetFloat("Score");
		tempF = Mathf.Floor(tempF);
		texto = "Your awesome score is " + tempF.ToString();
		//texto += PlayerPrefs.GetFloat("Score").ToString;
		theScore.text = texto;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void RestartGame()
	{
		SceneManager.LoadScene(0);
	}



}
