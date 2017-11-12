using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Copter : MonoBehaviour {

	public float timerBeforeResurect = 5;
	//public MeshRenderer myParent;
	public Helicopter myHelicopter;

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("copter"))
		{
			if(other.gameObject.transform.parent != transform.parent)
			{
                Copter c = other.gameObject.GetComponent<Copter>();

                other.gameObject.GetComponent<BoxCollider>().enabled = false;
				//transform.parent.GetComponent<BoxCollider>().enabled = false;
				MeshRenderer[] tempMR = transform.parent.GetComponentsInChildren<MeshRenderer>();
				foreach (MeshRenderer tMR in tempMR)
				{
					tMR.enabled = false;
				}
				Invoke("Ressurect", timerBeforeResurect);
				c.Invoke("Ressurect", timerBeforeResurect);

				myHelicopter.isDead = true;				
				c.myHelicopter.isDead = true;
              //  myParent.enabled = false;
              //  c.myParent.enabled = false;
			}	
		}
	}
	public void Ressurect()
	{
		Invoke("RessurectCollider", timerBeforeResurect);
		myHelicopter.isDead = false;
		MeshRenderer[] tempMR = transform.parent.GetComponentsInChildren<MeshRenderer>();
		foreach(MeshRenderer tMR in tempMR)
		{
			tMR.enabled = true;
		}
	}

	public void RessurectCollider()
	{
		GetComponent<BoxCollider>().enabled = true;
	}
}
