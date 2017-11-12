using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable][CreateAssetMenu]
public class Pose : ScriptableObject {
    public Vector2 leftHand;    
    public Vector2 leftElbow;
    public Vector2 rightHand;   
    public Vector2 rightElbow;
    public Vector2 leftFoot;   
    public Vector2 leftKnee;
    public Vector2 rightFoot;   
    public Vector2 rightKnee;

    public float midChest;
    public float pelvis;

    public float rotation;

    [Header("Bone Lengths")]
    public float leftForearm;
    public float leftArm;
    public float rightForearm;
    public float rightArm;
    public float leftShin;
    public float leftThigh;
    public float RightShin;
    public float RightThigh;


    void OnValidate()
    {
        leftForearm = Vector2.Distance(leftHand, leftElbow);
        leftArm = Vector2.Distance(leftElbow, new Vector2(-2, midChest));
        rightForearm = Vector2.Distance(rightHand, rightElbow);
        rightArm = Vector2.Distance(rightElbow, new Vector2(2, midChest));
        leftShin = Vector2.Distance(leftFoot, leftKnee);
        leftThigh = Vector2.Distance(leftKnee, new Vector2(-1, pelvis));
        RightShin = Vector2.Distance(rightFoot, rightKnee);
        RightThigh = Vector2.Distance(rightKnee, new Vector2(1, pelvis));
    }
}
