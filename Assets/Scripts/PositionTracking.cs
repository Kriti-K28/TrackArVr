using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleARCore;
using UnityEngine.UI;
public class PositionTracking : MonoBehaviour
{
    private Vector3 origPos;
    public Text test;

    private double prevTime = 0f,minVrFps=100f,maxVrFps=0f, minArFps=100f;
    void Start () {
        prevTime = Frame.Timestamp;
        origPos = gameObject.transform.position;
    }

    void Update () {

        // if (Frame.TrackingState == FrameTrackingState.Tracking)
        // {
        var pose = Frame.Pose;
        gameObject.transform.position = pose.position + origPos;
        
        //}
        if( 1f/(Frame.Timestamp - prevTime)<minArFps)
           minArFps= 1f/(Frame.Timestamp - prevTime);
        if( (1f / Time.deltaTime)>maxVrFps)
            maxVrFps= 1f / Time.deltaTime;
        if( (1f / Time.deltaTime)<minVrFps)
            minVrFps= 1f / Time.deltaTime;
        
         test.text = "AR FPS: " + System.Math.Round(1f/(Frame.Timestamp - prevTime),0) + "\n" + //approximate frames per second for AR tracking
                    "VR FPS: " + 1f / Time.deltaTime+"\n"+
                    "Pos:"+pose.position.ToString()+"\n"+
                   // "min AR FPS: "+System.Math.Round(minArFps,0)+"\n"+
                    "min AR FPS: "+System.Math.Round(minArFps,0)+"\n"+
                    "min VR FPS: "+System.Math.Round(minVrFps,0)+"\n"+
                    "max VR FPS: "+System.Math.Round(maxVrFps,0); //approximate frames per seconds for rendering
		prevTime = Frame.Timestamp;
        Debug.Log("Timestamp test: "+ Frame.Timestamp);
    }
}
