using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinEffectManager : MonoBehaviour
{

	public GameObject[] feuArtifice;
	public GameObject[] paysan;
	public float delayAfterDancing = 5f;

	private void Start()
	{
	//	SuccessEffect();
		FailEffect();
	}


	public void FailEffect()
	{
		SadDude();
	}



	public void SuccessEffect()
	{
		StartFire();
		DancingDude();
	}

	void StartFire()
	{
		foreach (GameObject gO in feuArtifice)
		{
			gO.SetActive(false);
			gO.SetActive(true);
		}
	}

	void DancingDude()
	{
		foreach (GameObject gO in paysan)
		{
			gO.GetComponent<Animator>().SetBool("isHappy", true);
		}
		Invoke("StopDancing", delayAfterDancing);
	}


	void StopDancing()
	{
		foreach (GameObject gO in paysan)
		{
			gO.GetComponent<Animator>().SetBool("isHappy", false);
		}
	}

	void SadDude()
	{
		foreach (GameObject gO in paysan)
		{
			gO.GetComponent<Animator>().SetBool("isSad", true);
		}
		Invoke("StopSad", delayAfterDancing);
	}

	void StopSad()
	{
		foreach (GameObject gO in paysan)
		{
			gO.GetComponent<Animator>().SetBool("isSad", false);
		}
	}
}
