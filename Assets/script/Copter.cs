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
		if(other.gameObject.tag == "copter")
		{
			return;
		}
	}

	public void turnOff()
	{
		//GetComponent<MeshRenderer>().Enabled = false;

	}

}
