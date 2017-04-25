using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerManager : MonoBehaviour {

    public static ControllerManager Instance;

    public SteamVR_TrackedObject rightController;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    private void OnDestroy()
    {
        if(Instance == this)
        {
            Instance = null;
        }
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
