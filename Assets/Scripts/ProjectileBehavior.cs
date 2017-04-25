using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent (typeof(Rigidbody))]
public class ProjectileBehavior : MonoBehaviour {


	private SteamVR_TrackedObject wand;


	private Rigidbody ball;
	private LineRenderer line;


	// Use this for initialization
	void Start () {
		ball = GetComponent<Rigidbody> ();

		line = GetComponent<LineRenderer> ();

        wand = ControllerManager.Instance.rightController;
	}
	
	// Update is called once per frame
	void Update () {
		SteamVR_Controller.Device device =  SteamVR_Controller.Input ((int)wand.index);
		if (device.GetTouch (SteamVR_Controller.ButtonMask.Trigger)) {

            Vector3 vel1 = transform.position - wand.transform.position;
            float lVel1 = vel1.magnitude;
            vel1.Normalize();

            Vector3 vel = device.velocity;
            float lVel = vel.magnitude;
            float dot = Vector3.Dot(vel, vel1);

			float triggerPress = device.GetState ().rAxis1.x; //get how much trigger is pressed!

            vel1 = -1f * triggerPress * vel1 * lVel * (-dot + 1);
            ball.AddForce (vel1);
            SpringJoint j = GetComponent<SpringJoint>();
            j.spring = 1 * triggerPress;				 
		} else
        {
            SpringJoint j = GetComponent<SpringJoint>();
            j.spring = 0;
        }
        line.SetPosition(0, transform.position);
        line.SetPosition(1, wand.transform.position);


    }
}
 