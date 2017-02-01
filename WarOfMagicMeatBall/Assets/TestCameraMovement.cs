using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCameraMovement : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.W))
			this.transform.Translate (0,0,-1,Space.World);
		else if (Input.GetKey (KeyCode.S))
			this.transform.Translate (0,0,1,Space.World);
		if (Input.GetKey (KeyCode.A))
			this.transform.Translate (1,0,0,Space.World);
		else if (Input.GetKey (KeyCode.D))
			this.transform.Translate (-1,0,0,Space.World);
	}
}
