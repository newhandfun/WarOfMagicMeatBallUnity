using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MySceneManager {

	MyScene myScene = null;

	public void OnAwake(){}

	public void OnStart(){
		myScene = new LoginScene(this);
		myScene.OnSenceStart ();
	}

	public void OnUpdate(){
		myScene.OnSenceUpdate ();
	}
}
