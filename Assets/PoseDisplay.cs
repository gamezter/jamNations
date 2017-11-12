using System.Collections;
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
    LineRenderer Head;

	// Use this for initialization
	void Awake () {
        GameObject leftA = new GameObject("Left arm");
        leftA.transform.parent = transform;
        leftA.layer = LayerMask.NameToLayer("UI");
        leftArm = leftA.AddComponent<LineRenderer>();
        leftArm.sortingOrder = 5;
        leftArm.sharedMaterial = m;
        leftArm.endWidth = leftArm.startWidth = lineWidth;
        leftArm.numCornerVertices = leftArm.numCapVertices = extraVertices;

        GameObject rightA = new GameObject("Right arm");
        rightA.transform.parent = transform;
        rightA.layer = LayerMask.NameToLayer("UI");
        rightArm = rightA.AddComponent<LineRenderer>();
        rightArm.sortingOrder = 5;
        rightArm.sharedMaterial = m;
        rightArm.endWidth = rightArm.startWidth = lineWidth;
        rightArm.numCornerVertices = rightArm.numCapVertices = extraVertices;

        GameObject leftL = new GameObject("Left leg");
        leftL.transform.parent = transform;
        leftL.layer = LayerMask.NameToLayer("UI");
        leftLeg = leftL.AddComponent<LineRenderer>();
        leftLeg.sortingOrder = 5;
        leftLeg.sharedMaterial = m;
        leftLeg.endWidth = leftLeg.startWidth = lineWidth;
        leftLeg.numCornerVertices = leftLeg.numCapVertices = extraVertices;

        GameObject rightL = new GameObject("Right leg");
        rightL.transform.parent = transform;
        rightL.layer = LayerMask.NameToLayer("UI");
        rightLeg = rightL.AddComponent<LineRenderer>();
        rightLeg.sortingOrder = 5;
        rightLeg.sharedMaterial = m;
        rightLeg.endWidth = rightLeg.startWidth = lineWidth;
        rightLeg.numCornerVertices = rightLeg.numCapVertices = extraVertices;

        GameObject body = new GameObject("Body");
        body.transform.parent = transform;
        body.layer = LayerMask.NameToLayer("UI");
        Body = body.AddComponent<LineRenderer>();
        Body.sortingOrder = 5;
        Body.sharedMaterial = m;
        Body.endWidth = Body.startWidth = lineWidth;
        Body.numCornerVertices = Body.numCapVertices = extraVertices;

        GameObject head = new GameObject("Head");
        head.transform.parent = transform;
        head.layer = LayerMask.NameToLayer("UI");
        Head = head.AddComponent<LineRenderer>();
        Head.sortingOrder = 5;
        Head.sharedMaterial = m;
        Head.endWidth = Head.startWidth = lineWidth * 2.0f;
        Head.numCapVertices = extraVertices;

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

        Body.positionCount = 3;
        Body.startColor = Color.red;
        Body.endColor = Color.red;

        Head.positionCount = 2;
        Head.startColor = Color.red;
        Head.endColor = Color.red;
    }

    public void UpdateDisplay(Pose p)
    {
        Vector3 o = transform.position;

        float s = Mathf.Sin(p.rotation);
        float c = Mathf.Cos(p.rotation);

        leftArm.SetPositions(new[] { o + new Vector3(p.leftHand.x * c - p.leftHand.y * s, p.leftHand.y * c + p.leftHand.x * s, 0), o + new Vector3(p.leftElbow.x * c - p.leftElbow.y * s, p.leftElbow.y * c + p.leftElbow.x * s, 0), o + new Vector3(-2 * c - p.midChest * s, p.midChest * c - 2 * s, 0), o + new Vector3( -p.midChest * s, p.midChest * c, 0) });

        rightArm.SetPositions(new[] { o + new Vector3(p.rightHand.x * c - p.rightHand.y * s, p.rightHand.y * c + p.rightHand.x * s, 0), o + new Vector3(p.rightElbow.x * c - p.rightElbow.x * s, p.rightElbow.y * c + p.rightElbow.x * s, 0), o + new Vector3(2 * c - p.midChest * s, p.midChest * c + 2 * s, 0), o + new Vector3(-p.midChest * s, p.midChest * c, 0) });

        leftLeg.SetPositions(new[] { o + new Vector3(p.leftFoot.x * c - p.leftFoot.y * s, p.leftFoot.y * c + p.leftFoot.x * s, 0), o + new Vector3(p.leftKnee.x * c - p.leftKnee.y * s, p.leftKnee.y * c + p.leftKnee.x * s, 0), o + new Vector3(-p.pelvis * s, p.pelvis * c, 0) });

        rightLeg.SetPositions(new[] { o + new Vector3(p.rightFoot.x * c - p.rightFoot.y * s, p.rightFoot.y, 0), o + new Vector3(p.rightKnee.x * c - p.rightKnee.y * s, p.rightKnee.y, 0), o + new Vector3(-p.pelvis * s, p.pelvis * c, 0)});

        Body.SetPositions(new[] { o + new Vector3(-p.pelvis * s, p.pelvis * c, 0), o + new Vector3(-p.midChest * s, p.midChest * c, 0), o + new Vector3(-(p.midChest + 2) * s, (p.midChest + 2) * c, 0)});

        Head.SetPositions(new[] { o + new Vector3(-(p.midChest + 2) * s, (p.midChest + 2) * c, 0), o + new Vector3(-(p.midChest + 3) * s, (p.midChest + 3) * c, 0)});
    }
}
