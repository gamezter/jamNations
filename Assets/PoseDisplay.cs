using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoseDisplay : MonoBehaviour {

    public Pose p;
    public Material m;
    public float depth;

    LineRenderer leftArm;
    LineRenderer rightArm;
    LineRenderer leftLeg;
    LineRenderer rightLeg;
    LineRenderer Body;

	// Use this for initialization
	void Start () {
        GameObject leftA = new GameObject("Left arm");
        leftA.transform.parent = transform;
        leftArm = leftA.AddComponent<LineRenderer>();
        leftArm.sharedMaterial = m;

        GameObject rightA = new GameObject("Right arm");
        rightA.transform.parent = transform;
        rightArm = rightA.AddComponent<LineRenderer>();
        rightArm.sharedMaterial = m;

        GameObject leftL = new GameObject("Left leg");
        leftL.transform.parent = transform;
        leftLeg = leftL.AddComponent<LineRenderer>();
        leftLeg.sharedMaterial = m;

        GameObject rightL = new GameObject("Right leg");
        rightL.transform.parent = transform;
        rightLeg = rightL.AddComponent<LineRenderer>();
        rightLeg.sharedMaterial = m;

        GameObject body = new GameObject("Body");
        body.transform.parent = transform;
        Body = body.AddComponent<LineRenderer>();
        Body.sharedMaterial = m;

        leftArm.positionCount = 4;
        leftArm.SetPositions(new []{ new Vector3(p.leftHand.x, p.leftHand.y, depth), new Vector3(p.leftElbow.x, p.leftElbow.y, depth), new Vector3(-2, p.midChest, depth), new Vector3(0, p.midChest, depth) });
        leftArm.startColor = Color.blue;
        leftArm.endColor = Color.red;

        rightArm.positionCount = 4;
        rightArm.SetPositions(new[] { new Vector3(p.rightHand.x, p.rightHand.y, depth), new Vector3(p.rightElbow.x, p.rightElbow.y, depth), new Vector3(2, p.midChest, depth), new Vector3(0, p.midChest, depth) });
        rightArm.startColor = Color.blue;
        rightArm.endColor = Color.red;

        leftLeg.positionCount = 4;
        leftLeg.SetPositions(new[] { new Vector3(p.leftFoot.x, p.leftFoot.y, depth), new Vector3(p.leftKnee.x, p.leftKnee.y, depth), new Vector3(-1, p.pelvis, depth), new Vector3(0, p.pelvis, depth) });
        leftLeg.startColor = Color.blue;
        leftLeg.endColor = Color.red;

        rightLeg.positionCount = 4;
        rightLeg.SetPositions(new[] { new Vector3(p.rightFoot.x, p.rightFoot.y, depth), new Vector3(p.rightKnee.x, p.rightKnee.y, depth), new Vector3(1, p.pelvis, depth), new Vector3(0, p.pelvis, depth) });
        rightLeg.startColor = Color.blue;
        rightLeg.endColor = Color.red;

        Body.positionCount = 2;
        Body.SetPositions(new[] { new Vector3(0, p.pelvis, depth), new Vector3(0, p.midChest, depth) });
        Body.startColor = Color.red;
        Body.endColor = Color.red;
    }
}
