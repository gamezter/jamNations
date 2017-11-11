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

    [Header("Bone Lengths")]
    public float leftForearmLength;
    public float leftArmLength;
    public float rightForearmLength;
    public float rightArmLength;
    public float leftShinLength;
    public float leftThighLength;
    public float RightShinLength;
    public float RightThighLength;


    void OnValidate()
    {
        leftForearmLength = Vector2.Distance(leftHand, leftElbow);
        leftArmLength = Vector2.Distance(leftElbow, new Vector2(-2, midChest));
        rightForearmLength = Vector2.Distance(rightHand, rightElbow);
        rightArmLength = Vector2.Distance(rightElbow, new Vector2(2, midChest));
        leftShinLength = Vector2.Distance(leftFoot, leftKnee);
        leftThighLength = Vector2.Distance(leftKnee, new Vector2(-1, pelvis));
        RightShinLength = Vector2.Distance(rightFoot, rightKnee);
        RightThighLength = Vector2.Distance(rightKnee, new Vector2(1, pelvis));
    }
}
