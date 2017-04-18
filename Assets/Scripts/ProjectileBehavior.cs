using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent (typeof(Rigidbody))]
public class ProjectileBehavior : MonoBehaviour {


	public SteamVR_TrackedObject wand;


	private Rigidbody ball;

	// Use this for initialization
	void Start () {
		ball = GetComponent<Rigidbody> ();

	}
	
	// Update is called once per frame
	void Update () {
		var device = SteamVR_Controller.Input ((int)wand.index);
		if (Joint == null && device.GetTouchDown (SteamVR_Controller.ButtonMask.Trigger)) {
			float triggerPress = device.GetState ().rAxis1.x; //get how much trigger is pressed!
			Vector3 direction = wand.transform.position - transform.position; 
			ball.AddForce (direction.normalize * 5f * triggerPress);

			 
		}
		
	}
}
 