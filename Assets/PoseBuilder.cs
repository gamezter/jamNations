using UnityEngine;

public class PoseBuilder : MonoBehaviour {

    public Pose p;

    private void OnDrawGizmos()
    {
        Vector3 o = transform.position;
        Gizmos.color = Color.red;

        float s = Mathf.Sin(p.rotation);
        float c = Mathf.Cos(p.rotation);

        Vector3 one = new Vector3(p.leftHand.x, p.leftHand.y, 0);
        Vector3 two = new Vector3(p.leftElbow.x, p.leftElbow.y, 0);
        Gizmos.DrawLine(o + new Vector3(one.x * c - one.y * s, one.y * c + one.x * s, one.z), o + new Vector3(two.x * c - two.y * s, two.y * c + two.x * s, two.z));

        one = new Vector3(p.leftElbow.x, p.leftElbow.y);
        two = new Vector3(-2, p.midChest, 0);
        Gizmos.DrawLine(o + new Vector3(one.x * c - one.y * s, one.y * c + one.x * s, one.z), o + new Vector3(two.x * c - two.y * s, two.y * c + two.x * s, two.z));

        one = new Vector3(-2, p.midChest, 0);
        two = new Vector3(2, p.midChest, 0);
        Gizmos.DrawLine(o + new Vector3(one.x * c - one.y * s, one.y * c + one.x * s, one.z), o + new Vector3(two.x * c - two.y * s, two.y * c + two.x * s, two.z));

        one = new Vector3(2, p.midChest, 0);
        two = new Vector3(p.rightElbow.x, p.rightElbow.y, 0);
        Gizmos.DrawLine(o + new Vector3(one.x * c - one.y * s, one.y * c + one.x * s, one.z), o +  new Vector3(two.x * c - two.y * s, two.y * c + two.x * s, two.z));

        one = new Vector3(p.rightElbow.x, p.rightElbow.y, 0);
        two = new Vector3(p.rightHand.x, p.rightHand.y, 0);
        Gizmos.DrawLine(o + new Vector3(one.x * c - one.y * s, one.y * c + one.x * s, one.z), o + new Vector3(two.x * c - two.y * s, two.y * c + two.x * s, two.z));

        one = new Vector3(0, p.midChest, 0);
        two = new Vector3(0, p.pelvis, 0);
        Gizmos.DrawLine(o + new Vector3(one.x * c - one.y * s, one.y * c + one.x * s, one.z), o + new Vector3(two.x * c - two.y * s, two.y * c + two.x * s, two.z));

        one = new Vector3(p.leftFoot.x, p.leftFoot.y, 0);
        two = new Vector3(p.leftKnee.x, p.leftKnee.y, 0);
        Gizmos.DrawLine(o + new Vector3(one.x * c - one.y * s, one.y * c + one.x * s, one.z), o + new Vector3(two.x * c - two.y * s, two.y * c + two.x * s, two.z));

        one = new Vector3(p.leftKnee.x, p.leftKnee.y, 0);
        two = new Vector3(-1, p.pelvis, 0);
        Gizmos.DrawLine(o + new Vector3(one.x * c - one.y * s, one.y * c + one.x * s, one.z), o + new Vector3(two.x * c - two.y * s, two.y * c + two.x * s, two.z));

        one = new Vector3(-1, p.pelvis, 0);
        two = new Vector3(1, p.pelvis, 0);
        Gizmos.DrawLine(o + new Vector3(one.x * c - one.y * s, one.y * c + one.x * s, one.z), o + new Vector3(two.x * c - two.y * s, two.y * c + two.x * s, two.z));

        one = new Vector3(1, p.pelvis, 0);
        two = new Vector3(p.rightKnee.x, p.rightKnee.y, 0);
        Gizmos.DrawLine(o + new Vector3(one.x * c - one.y * s, one.y * c + one.x * s, one.z), o + new Vector3(two.x * c - two.y * s, two.y * c + two.x * s, two.z));

        one = new Vector3(p.rightKnee.x, p.rightKnee.y, 0);
        two = new Vector3(p.rightFoot.x, p.rightFoot.y, 0);
        Gizmos.DrawLine(o + new Vector3(one.x * c - one.y * s, one.y * c + one.x * s, one.z), o + new Vector3(two.x * c - two.y * s, two.y * c + two.x * s, two.z));
        

        Gizmos.DrawSphere(o + new Vector3(p.leftHand.x * c - p.leftHand.y * s, p.leftHand.y * c + p.leftHand.x * s, 0), 0.5f);
        Gizmos.DrawSphere(o + new Vector3(p.leftElbow.x * c - p.leftElbow.y * s, p.leftElbow.y * c + p.leftElbow.x * s, 0), 0.5f);
        Gizmos.DrawSphere(o + new Vector3(p.rightElbow.x * c - p.rightElbow.y * s, p.rightElbow.y * c + p.rightElbow.x * s, 0), 0.5f);
        Gizmos.DrawSphere(o + new Vector3(p.rightHand.x * c - p.rightHand.y * s, p.rightHand.y * c + p.rightHand.x * s, 0), 0.5f);
        Gizmos.DrawSphere(o + new Vector3(p.leftFoot.x * c - p.leftFoot.y * s, p.leftFoot.y * c + p.leftFoot.x * s, 0), 0.5f);
        Gizmos.DrawSphere(o + new Vector3(p.leftKnee.x * c - p.leftKnee.y * s, p.leftKnee.y * c + p.leftKnee.x * s, 0), 0.5f);
        Gizmos.DrawSphere(o + new Vector3(p.rightKnee.x * c - p.rightKnee.y * s, p.rightKnee.y * c + p.rightKnee.x * s, 0), 0.5f);
        Gizmos.DrawSphere(o + new Vector3(p.rightFoot.x * c - p.rightFoot.y * s, p.rightFoot.y * c + p.rightFoot.x * s, 0), 0.5f);
    }
}
