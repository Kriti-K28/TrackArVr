using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleARCore;
using UnityEngine.UI;
public class PositionTracking : MonoBehaviour
{
    private Vector3 origPos;
    public Text test;
    
    void Start () {
        origPos = gameObject.transform.position;
    }

    void Update () {

        // if (Frame.TrackingState == FrameTrackingState.Tracking)
        // {
        var pose = Frame.Pose;
        gameObject.transform.position = pose.position + origPos;
        test.text=pose.position.ToString();
        //}
    }
}
