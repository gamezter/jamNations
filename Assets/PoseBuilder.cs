using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoseBuilder : MonoBehaviour {

    public Pose p;
    public float midChest;
    public float shoulderWidth;
    public float pelvis;
    public float hipWidth;

    private void OnDrawGizmos()
    {
        Vector3 o = transform.position;
        Gizmos.color = Color.red;
        Gizmos.DrawLine(o + new Vector3(p.leftHand.x, p.leftHand.y, 0), o + new Vector3(p.leftElbow.x, p.leftElbow.y, 0));
        Gizmos.DrawLine(o + new Vector3(p.leftElbow.x, p.leftElbow.y), o + new Vector3(-shoulderWidth, midChest, 0));
        Gizmos.DrawLine(o + new Vector3(-shoulderWidth, midChest, 0), o + new Vector3(shoulderWidth, midChest, 0));
        Gizmos.DrawLine(o + new Vector3(shoulderWidth, midChest, 0), o + new Vector3(p.rightElbow.x, p.rightElbow.y, 0));
        Gizmos.DrawLine(o + new Vector3(p.rightElbow.x, p.rightElbow.y, 0), new Vector3(p.rightHand.x, p.rightHand.y, 0));
        Gizmos.DrawLine(o + new Vector3(0, midChest, 0), o + new Vector3(0, pelvis, 0));
        Gizmos.DrawLine(o + new Vector3(p.leftFoot.x, p.leftFoot.y, 0), o + new Vector3(p.leftKnee.x, p.leftKnee.y, 0));
        Gizmos.DrawLine(o + new Vector3(p.leftKnee.x, p.leftKnee.y, 0), o + new Vector3(-hipWidth, pelvis, 0));
        Gizmos.DrawLine(o + new Vector3(-hipWidth, pelvis, 0), o + new Vector3(hipWidth, pelvis, 0));
        Gizmos.DrawLine(o + new Vector3(hipWidth, pelvis, 0), o + new Vector3(p.rightKnee.x, p.rightKnee.y, 0));
        Gizmos.DrawLine(o + new Vector3(p.rightKnee.x, p.rightKnee.y, 0), o + new Vector3(p.rightFoot.x, p.rightFoot.y, 0));


        Gizmos.DrawSphere(o + new Vector3(p.leftHand.x, p.leftHand.y, 0), 0.5f);
        Gizmos.DrawSphere(o + new Vector3(p.leftElbow.x, p.leftElbow.y, 0), 0.5f);
        Gizmos.DrawSphere(o + new Vector3(p.rightElbow.x, p.rightElbow.y, 0), 0.5f);
        Gizmos.DrawSphere(o + new Vector3(p.rightHand.x, p.rightHand.y, 0), 0.5f);
        Gizmos.DrawSphere(o + new Vector3(p.leftFoot.x, p.leftFoot.y, 0), 0.5f);
        Gizmos.DrawSphere(o + new Vector3(p.leftKnee.x, p.leftKnee.y, 0), 0.5f);
        Gizmos.DrawSphere(o + new Vector3(p.rightKnee.x, p.rightKnee.y, 0), 0.5f);
        Gizmos.DrawSphere(o + new Vector3(p.rightFoot.x, p.rightFoot.y, 0), 0.5f);
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
