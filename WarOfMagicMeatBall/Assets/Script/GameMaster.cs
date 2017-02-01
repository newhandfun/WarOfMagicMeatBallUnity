using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour {

	MySceneManager mySceneManager = new MySceneManager ();

	void Awake(){
		mySceneManager.OnAwake ();
	}

	void Start(){
		mySceneManager.OnStart ();
	}

	void Update(){
		mySceneManager.OnUpdate ();
	}
}
