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
}
