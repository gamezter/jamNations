using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    public int stagedelay;
    public Text DelayText;
    public PoseDisplay poseDisplay;
    public Pose[] poses;
    public float maxDistance;
    public float score;

    public GameObject parent;
    public GameObject leftHandTarget;
    public GameObject leftElbowTarget;
    public GameObject rightHandTarget;
    public GameObject rightElbowTarget;
    public GameObject leftKneeTarget;
    public GameObject leftFootTarget;
    public GameObject rightKneeTarget;
    public GameObject rightFootTarget;

    private int currentIndex;

    float delay;

	// Use this for initialization
	void Start () {
        delay = stagedelay;
        currentIndex = Random.Range(0, poses.Length - 1);
        poseDisplay.UpdateDisplay(poses[currentIndex]);
    }
	
	// Update is called once per frame
	void Update () {
        delay -= Time.deltaTime;
        DelayText.text = "Time remaining: " + Mathf.Floor(delay).ToString();

        if(delay < 0)
        {
            //times up
            delay = stagedelay;

            score = 0;
            Pose p = poses[currentIndex];
            float c = Mathf.Cos(p.rotation);
            float s = Mathf.Sin(p.rotation);

            Vector3 leftHand = new Vector3(p.leftHand.x * s - p.leftHand.y * c, p.leftHand.y * s + p.leftHand.x * c, 0);
            Vector3 leftElbow = new Vector3(p.leftElbow.x * s - p.leftElbow.y * c, p.leftElbow.y * s + p.leftElbow.x * c, 0);
            Vector3 rightHand = new Vector3(p.rightHand.x * s - p.rightHand.y * c, p.rightHand.y * s + p.rightHand.x * c, 0);
            Vector3 rightElbow = new Vector3(p.rightElbow.x * s - p.rightElbow.y * c, p.rightElbow.y * s + p.rightElbow.x * c, 0);
            Vector3 leftKnee = new Vector3(p.leftKnee.x * s - p.leftKnee.y * c, p.leftKnee.y * s + p.leftKnee.x * c, 0);
            Vector3 leftFoot = new Vector3(p.leftFoot.x * s - p.leftFoot.y * c, p.leftFoot.y * s + p.leftFoot.x * c, 0);
            Vector3 rightKnee = new Vector3(p.rightKnee.x * s - p.rightKnee.y * c, p.rightKnee.y * s + p.rightKnee.x * c, 0);
            Vector3 rightFoot = new Vector3(p.rightFoot.x * s - p.rightFoot.y * c, p.rightFoot.y * s + p.rightFoot.x * c, 0);

            score += Mathf.Max(100 - (leftHand - leftHandTarget.transform.position + parent.transform.position).magnitude * 100 / maxDistance, 0.0f);
            score += Mathf.Max(100 - (leftElbow - leftElbowTarget.transform.position + parent.transform.position).magnitude * 50 / maxDistance, 0.0f);
            score += Mathf.Max(100 - (rightHand - rightHandTarget.transform.position + parent.transform.position).magnitude * 100 / maxDistance, 0.0f);
            score += Mathf.Max(100 - (rightElbow - rightElbowTarget.transform.position + parent.transform.position).magnitude * 50 / maxDistance, 0.0f);
            score += Mathf.Max(100 - (leftKnee - leftKneeTarget.transform.position + parent.transform.position).magnitude * 50 / maxDistance, 0.0f);
            score += Mathf.Max(100 - (leftFoot - leftFootTarget.transform.position + parent.transform.position).magnitude * 100 / maxDistance, 0.0f);
            score += Mathf.Max(100 - (rightKnee - rightKneeTarget.transform.position + parent.transform.position).magnitude * 50 / maxDistance, 0.0f);
            score += Mathf.Max(100 - (rightFoot - rightFootTarget.transform.position + parent.transform.position).magnitude * 100 / maxDistance, 0.0f);

            score /= 8;

            currentIndex = currentIndex == poses.Length - 1 ? 0 : currentIndex + 1;
            poseDisplay.UpdateDisplay(poses[currentIndex]);
        }
	}
}
