using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Copter : MonoBehaviour {

	public float timerBeforeResurect = 5;
	public MeshRenderer myParent;
	public Helicopter myHelicopter;

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("copter"))
		{
			if(other.gameObject.transform.parent != transform.parent)
			{
                Copter c = other.gameObject.GetComponent<Copter>();

                other.gameObject.GetComponent<BoxCollider>().enabled = false;
				GetComponent<BoxCollider>().enabled = false;

				Invoke("Ressurect", timerBeforeResurect);
				c.Invoke("Ressurect", timerBeforeResurect);

				myHelicopter.isDead = true;				
				c.myHelicopter.isDead = true;
                myParent.enabled = false;
                c.myParent.enabled = false;
			}	
		}
	}
	public void Ressurect()
	{
		Invoke("RessurectCollider", timerBeforeResurect);
		myHelicopter.isDead = false;
		myParent.enabled = true;
	}

	public void RessurectCollider()
	{
		GetComponent<BoxCollider>().enabled = true;
	}
}
