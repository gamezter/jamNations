using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    public int stagedelay;
    public Text DelayText;
    public PoseDisplay poseDisplay;
    public Pose[] poses;

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
            currentIndex = currentIndex == poses.Length - 1 ? 0 : currentIndex + 1;
            poseDisplay.UpdateDisplay(poses[currentIndex]);
        }
	}
}
