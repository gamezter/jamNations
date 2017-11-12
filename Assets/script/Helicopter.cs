using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helicopter : MonoBehaviour {

    public Material chainMaterial;
    public bool left;
    public string axis;
    public float linkHeight;
    public int chainLength;
    public float linkMass;
    public float linkAngularDrag;
    public Vector3 chainOffset;
    public Rigidbody attachee;
    private List<GameObject> links;
    private LineRenderer lr;
	public bool isDead;
	// Use this for initialization
	void Start () {
        links = new List<GameObject>();
        lr = gameObject.AddComponent<LineRenderer>();
        lr.sharedMaterial = chainMaterial;
        lr.positionCount = chainLength * 2 + 2;
        lr.startWidth = 0.2f;
        lr.endWidth = 0.2f;
        BuildChain();
	}
	
	// Update is called once per frame
	void Update () {
		if (!isDead)
		{
				
        float x = Input.GetAxis(axis + "H") * 0.1f;
        float y = Input.GetAxis(axis + "V") * 0.1f;
        transform.position += new Vector3(x, y, 0);

        lr.SetPosition(0, links[0].transform.position + links[0].transform.up * 1.5f);

        for (int i = 0; i < links.Count - 1; i ++)
        {
            Vector3 pos0 = links[i].transform.position + links[i].transform.up * 1.5f;
            Vector3 pos1 = links[i + 1].transform.position + links[i + 1].transform.up * 1.5f;

            lr.SetPosition(i * 2 + 1, pos0 * 0.66f + pos1 * 0.33f);
            lr.SetPosition(i * 2 + 2, pos0 * 0.33f + pos1 * 0.66f);

        }
        Vector3 p0 = links[links.Count - 1].transform.position + links[links.Count - 1].transform.up * 1.5f;
        Vector3 p1 = links[links.Count - 1].transform.position - links[links.Count - 1].transform.up * 1.5f;

        lr.SetPosition(chainLength * 2 - 1, p0 * 0.66f + p1 * 0.33f);
        lr.SetPosition(chainLength * 2, p0 * 0.33f + p1 * 0.66f);

        lr.SetPosition(chainLength * 2 + 1, links[links.Count - 1].transform.position - links[links.Count - 1].transform.up * 1.5f);
		}
	}

	void BuildChain()
    {
        GameObject last = null;
        JointLimits l = new JointLimits { min = -90, max = 90 };

        for (int i = 0; i < chainLength; i++)
        {
            GameObject t = new GameObject();
            t.transform.localScale = new Vector3(0.1f, linkHeight, 0.1f);
            if(i == 0)
            {
                t.transform.position = transform.position + chainOffset - new Vector3(0, linkHeight, 0);
            }
            else
            {
                t.transform.position = last.transform.position - new Vector3(0, linkHeight * 2.0f, 0);
            }
            

            Rigidbody rb = t.AddComponent<Rigidbody>();
            rb.mass = linkMass;
            rb.angularDrag = linkAngularDrag;

            HingeJoint joint = t.AddComponent<HingeJoint>();
            joint.anchor = new Vector3(0, 1, 0);
            joint.axis = Vector3.forward;
            joint.autoConfigureConnectedAnchor = false;

            if (i == 0)
            {
                joint.connectedBody = gameObject.GetComponent<Rigidbody>();
                joint.connectedAnchor = new Vector3(0, -0.5f, 0);
            }
            else
            {
                joint.connectedBody = last.GetComponent<Rigidbody>();
                joint.connectedAnchor = new Vector3(0, -1, 0);
            }
            joint.useLimits = true;
            joint.limits = l;
            last = t;
            links.Add(t);
        }

        HingeJoint second = last.AddComponent<HingeJoint>();
        second.anchor = new Vector3(0, -1, 0);
        second.axis = Vector3.forward;
        second.autoConfigureConnectedAnchor = false;
        second.connectedBody = attachee;
        second.connectedAnchor = new Vector3(left ? 5 : -5, -15, 0);

    }
}
