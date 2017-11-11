using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Copter : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collision other)
	{
		Debug.Log("Je touche un autre object");
		if (other.gameObject.CompareTag("copter"))
		{
			Debug.Log("Je touche un autre copter");
			turnOff();
		}
	}

	void OnTriggerEnter(Collision other)
	{
		Debug.Log("Je touche un autre object");
		if (other.gameObject.CompareTag("copter"))
		{
		//	if(other.gameObject.transform.parent)
			Debug.Log("Je touche un autre copter");
			turnOff();
		}
	}


	public void turnOff()
	{
		GetComponent<MeshRenderer>().enabled = false;

	}

}
