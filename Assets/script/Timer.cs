using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    public float stagedelay;
    public PoseDisplay poseDisplay;
    public Pose[] poses;
    public float maxDistance;
    public float score;
    public Text MoveName;
    private float TotalScore = 0;

    public GameObject[] bubbles;

    public float minY;
    public float maxY;

    public Animator foule1;
    public Animator foule2;
    public Animator foule3;
    private int lives = 3;

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
    private int currentBubbleIndex = 0;
	public AudioSource myRadio;
	public AudioClip winningClip;
    float delay;

	// Use this for initialization
	void Start () {
        delay = stagedelay;
        currentIndex = Random.Range(0, poses.Length - 1);
        for(int i = 0; i < bubbles.Length; i++)
        {
            bubbles[i].SetActive(false);
        }

        bubbles[currentBubbleIndex].SetActive(true);
        Vector3 fromCamera = bubbles[currentBubbleIndex].transform.position - Camera.main.transform.position;
        poseDisplay.transform.position = bubbles[currentBubbleIndex].transform.position + new Vector3(0, 7, 0) + fromCamera.normalized * 90;

        Vector3 pos = bubbles[currentBubbleIndex].transform.GetChild(0).transform.localPosition;
        bubbles[currentBubbleIndex].transform.GetChild(0).transform.localPosition = new Vector3(pos.x, maxY, pos.z);

        poseDisplay.UpdateDisplay(poses[currentIndex]);
        MoveName.text = poses[currentIndex].poseName;
    }
	
	// Update is called once per frame
	void Update () {
        delay -= Time.deltaTime;

        float value = Mathf.Lerp(minY, maxY, delay / stagedelay);

        Vector3 pos = bubbles[currentBubbleIndex].transform.GetChild(0).transform.localPosition;
        bubbles[currentBubbleIndex].transform.GetChild(0).transform.localPosition = new Vector3(pos.x, value, pos.z);

        if (delay < 0)
        {
            //times up
            if (stagedelay > 3.0) stagedelay -= 0.5f;
            delay = stagedelay;

            score = 0;
            Pose p = poses[currentIndex];
            float c = Mathf.Cos(p.rotation);
            float s = Mathf.Sin(p.rotation);

            Vector3 leftHand = new Vector3(p.leftHand.x * s - p.leftHand.y * c, p.leftHand.y * s + p.leftHand.x * c, 0);
           // Vector3 leftElbow = new Vector3(p.leftElbow.x * s - p.leftElbow.y * c, p.leftElbow.y * s + p.leftElbow.x * c, 0);
            Vector3 rightHand = new Vector3(p.rightHand.x * s - p.rightHand.y * c, p.rightHand.y * s + p.rightHand.x * c, 0);
          //  Vector3 rightElbow = new Vector3(p.rightElbow.x * s - p.rightElbow.y * c, p.rightElbow.y * s + p.rightElbow.x * c, 0);
          //  Vector3 leftKnee = new Vector3(p.leftKnee.x * s - p.leftKnee.y * c, p.leftKnee.y * s + p.leftKnee.x * c, 0);
            Vector3 leftFoot = new Vector3(p.leftFoot.x * s - p.leftFoot.y * c, p.leftFoot.y * s + p.leftFoot.x * c, 0);
         //   Vector3 rightKnee = new Vector3(p.rightKnee.x * s - p.rightKnee.y * c, p.rightKnee.y * s + p.rightKnee.x * c, 0);
            Vector3 rightFoot = new Vector3(p.rightFoot.x * s - p.rightFoot.y * c, p.rightFoot.y * s + p.rightFoot.x * c, 0);

            score += Mathf.Max(100 - (leftHand - leftHandTarget.transform.position + parent.transform.position).magnitude * 100 / maxDistance, 0.0f);
         //   score += Mathf.Max(100 - (leftElbow - leftElbowTarget.transform.position + parent.transform.position).magnitude * 50 / maxDistance, 0.0f);
            score += Mathf.Max(100 - (rightHand - rightHandTarget.transform.position + parent.transform.position).magnitude * 100 / maxDistance, 0.0f);
        //    score += Mathf.Max(100 - (rightElbow - rightElbowTarget.transform.position + parent.transform.position).magnitude * 50 / maxDistance, 0.0f);
       //     score += Mathf.Max(100 - (leftKnee - leftKneeTarget.transform.position + parent.transform.position).magnitude * 50 / maxDistance, 0.0f);
            score += Mathf.Max(100 - (leftFoot - leftFootTarget.transform.position + parent.transform.position).magnitude * 100 / maxDistance, 0.0f);
      //      score += Mathf.Max(100 - (rightKnee - rightKneeTarget.transform.position + parent.transform.position).magnitude * 50 / maxDistance, 0.0f);
            score += Mathf.Max(100 - (rightFoot - rightFootTarget.transform.position + parent.transform.position).magnitude * 100 / maxDistance, 0.0f);

            score /= 8;
            TotalScore += score;

            if(score < 50)
            {
				Debug.Log("je suis poche jai pas un bon score");
                switch (lives)
                {
                    case 3:
                        foule3.SetBool("Leave", true);
                        foule3.speed = 1;
                        lives--;
                        break;
                    case 2:
                        foule2.SetBool("Leave", true);
                        foule2.speed = 1;
                        lives--;
                        break;
                    case 1:
                        foule1.SetBool("Leave", true);
                        foule1.speed = 1;
                        lives--;
                        break;
                    case 0:
                        PlayerPrefs.SetFloat("Score", TotalScore);
						SceneManager.LoadScene(2);
                        //GAME OVER
                        break;
                }
            }
            else if(score > 60)
            {
				myRadio.Play();
                switch (lives)
                {
					case 3:
						foule1.SetBool("Happy", true);
						foule2.SetBool("Happy", true);
						foule3.SetBool("Happy", true);
						break;
					case 2:
                        foule2.SetBool("Leave", false);
						foule1.SetBool("Happy", true);
						//foule1.SetBool("")

						foule2.speed = -1;
                        lives++;
                        break;
                    case 1:
                        foule1.SetBool("Leave", false);
                        foule1.speed = -1;
                        lives++;
                        break;
                }
				foule1.SetBool("Happy", false);
				foule2.SetBool("Happy", false);
				foule3.SetBool("Happy", false);
			}

            currentIndex = currentIndex == poses.Length - 1 ? 0 : currentIndex + 1;

            bubbles[currentBubbleIndex].SetActive(false);
            currentBubbleIndex = currentBubbleIndex == bubbles.Length - 1 ? 0 : currentBubbleIndex + 1;
            bubbles[currentBubbleIndex].SetActive(true);
            Vector3 fromCamera = bubbles[currentBubbleIndex].transform.position - Camera.main.transform.position;
            poseDisplay.transform.position = bubbles[currentBubbleIndex].transform.position + new Vector3(0,7,0) + fromCamera.normalized * 90;

            pos = bubbles[currentBubbleIndex].transform.GetChild(0).transform.localPosition;
            bubbles[currentBubbleIndex].transform.GetChild(0).transform.localPosition = new Vector3(pos.x, maxY, pos.z);

            poseDisplay.UpdateDisplay(poses[currentIndex]);
            MoveName.text = poses[currentIndex].poseName;
        }
	}
}
