﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoseDisplay : MonoBehaviour {

    public Material m;
    public float lineWidth;
    public int extraVertices;
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
        leftArm.endWidth = leftArm.startWidth = lineWidth;
        leftArm.numCornerVertices = leftArm.numCapVertices = extraVertices;

        GameObject rightA = new GameObject("Right arm");
        rightA.transform.parent = transform;
        rightArm = rightA.AddComponent<LineRenderer>();
        rightArm.sharedMaterial = m;
        rightArm.endWidth = rightArm.startWidth = lineWidth;
        rightArm.numCornerVertices = rightArm.numCapVertices = extraVertices;

        GameObject leftL = new GameObject("Left leg");
        leftL.transform.parent = transform;
        leftLeg = leftL.AddComponent<LineRenderer>();
        leftLeg.sharedMaterial = m;
        leftLeg.endWidth = leftLeg.startWidth = lineWidth;
        leftLeg.numCornerVertices = leftLeg.numCapVertices = extraVertices;

        GameObject rightL = new GameObject("Right leg");
        rightL.transform.parent = transform;
        rightLeg = rightL.AddComponent<LineRenderer>();
        rightLeg.sharedMaterial = m;
        rightLeg.endWidth = rightLeg.startWidth = lineWidth;
        rightLeg.numCornerVertices = rightLeg.numCapVertices = extraVertices;

        GameObject body = new GameObject("Body");
        body.transform.parent = transform;
        Body = body.AddComponent<LineRenderer>();
        Body.sharedMaterial = m;
        Body.endWidth = Body.startWidth = lineWidth;
        Body.numCornerVertices = Body.numCapVertices = extraVertices;

        leftArm.positionCount = 4;
        leftArm.startColor = Color.blue;
        leftArm.endColor = Color.red;

        rightArm.positionCount = 4;
        rightArm.startColor = Color.blue;
        rightArm.endColor = Color.red;

        leftLeg.positionCount = 3;
        leftLeg.startColor = Color.blue;
        leftLeg.endColor = Color.red;

        rightLeg.positionCount = 3;
        rightLeg.startColor = Color.blue;
        rightLeg.endColor = Color.red;

        Body.positionCount = 2;
        Body.startColor = Color.red;
        Body.endColor = Color.red;
    }

    public void UpdateDisplay(Pose p)
    {
        leftArm.SetPositions(new[] { new Vector3(p.leftHand.x, p.leftHand.y, depth), new Vector3(p.leftElbow.x, p.leftElbow.y, depth), new Vector3(-2, p.midChest, depth), new Vector3(0, p.midChest, depth) });

        rightArm.SetPositions(new[] { new Vector3(p.rightHand.x, p.rightHand.y, depth), new Vector3(p.rightElbow.x, p.rightElbow.y, depth), new Vector3(2, p.midChest, depth), new Vector3(0, p.midChest, depth) });

        leftLeg.SetPositions(new[] { new Vector3(p.leftFoot.x, p.leftFoot.y, depth), new Vector3(p.leftKnee.x, p.leftKnee.y, depth), new Vector3(0, p.pelvis, depth) });

        rightLeg.SetPositions(new[] { new Vector3(p.rightFoot.x, p.rightFoot.y, depth), new Vector3(p.rightKnee.x, p.rightKnee.y, depth), new Vector3(0, p.pelvis, depth) });

        Body.SetPositions(new[] { new Vector3(0, p.pelvis, depth), new Vector3(0, p.midChest, depth) });
    }
}
