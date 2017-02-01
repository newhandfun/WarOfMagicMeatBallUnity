using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MyScene : MonoBehaviour{

	protected MySceneManager mySceneManager = null;

	private string sceneName = "Sence";
	public string SceneName{
		get{ return sceneName;}
		set{ sceneName = value;}
	}

	public MyScene(){
	}

	public MyScene(MySceneManager _mySenceManager){
		mySceneManager = _mySenceManager;
	}

	public virtual void Handle(){}

	public virtual void OnSenceStart(){}

	public virtual void OnSenceUpdate(){}

	public virtual void OnSenceExit(){}

	public override string ToString(){
		return string.Format ("[Sence : Name = {0}]", sceneName);
	}
}

public class LoginScene : MyScene{
	public LoginScene (MySceneManager _mySceneManager):base(_mySceneManager){
		SceneName = "LogIn";
	}

	public override void OnSenceStart ()
	{
		SceneManager.LoadScene ("LogIn",LoadSceneMode.Single);
	}

	public override void OnSenceUpdate ()
	{
		
	}
}

public class VillageScence : MyScene{
	public VillageScence (MySceneManager _mySceneManager):base(_mySceneManager){
		SceneName = "Village";
	}

	public override void OnSenceStart ()
	{
		SceneManager.LoadScene ("Village",LoadSceneMode.Single);
	}


}
