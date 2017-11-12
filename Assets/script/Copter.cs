using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Copter : MonoBehaviour {

	public float timerBeforeResurect = 5;
	public MeshRenderer myParent;
	public Helicopter myHelicopter;
	void OnCollisionEnter(Collision other)
	{
		Debug.Log("Je touche un autre object");
		if (other.gameObject.CompareTag("copter"))
		{
			Debug.Log("Je touche un autre copter");
			turnOff();
		}
	}

	void OnTriggerEnter(Collider other)
	{
		//Debug.Log("Je touche un autre object");
		if (other.gameObject.CompareTag("copter"))
		{
			if(other.gameObject.transform.parent != this.transform.parent)
			{
				other.gameObject.GetComponent<MeshRenderer>().enabled = false;
				turnOff();
				other.gameObject.GetComponent<BoxCollider>().enabled = false;
				GetComponent<BoxCollider>().enabled = false;
				Invoke("Ressurect", timerBeforeResurect);
				other.gameObject.GetComponent<Copter>().Invoke("Ressurect", timerBeforeResurect);
				myHelicopter.isDead = true;
				myParent.enabled = false;
				other.gameObject.GetComponent<Copter>().myHelicopter.isDead = true;
				other.gameObject.GetComponent<Copter>().myParent.enabled = false;
			}
		//	Debug.Log("Je touche un autre copter");
			
		}
	}


	public void turnOff()
	{
		GetComponent<MeshRenderer>().enabled = false;

	}

	public void Ressurect()
	{
		Invoke("RessurectCollider", timerBeforeResurect);
		GetComponent<MeshRenderer>().enabled = true;
		myHelicopter.isDead = false;
		myParent.enabled = true;
	}

	public void RessurectCollider()
	{
		GetComponent<BoxCollider>().enabled = true;
	}
}
