using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class MyScene{

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

    public abstract void OnSenceStart();

    public abstract void OnSenceUpdate();

    public abstract void OnSenceExit();

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
        WOMMGame.Instance.ShowLoginUI(Login);
        WOMMGame.Instance.SetMainMeatBall(new Vector3(1.88f, 0f, -6.09f));
        WOMMGame.Instance.SetMainMeatBallStandBy();
    }

	public override void OnSenceUpdate ()
	{
		
	}

    public override void OnSenceExit()
    {
        WOMMGame.Instance.HideLoginUI();
    }

    private void Login() {
        mySceneManager.SetScene(new MeatBallChooserScene(mySceneManager));
    }
}

public class MeatBallChooserScene : MyScene{
    public MeatBallChooserScene(MySceneManager _mySceneManager) : base(_mySceneManager)
    {
        SceneName = "MeatBallPickScene";
    }

    public override void OnSenceExit()
    {
        WOMMGame.Instance.HideChooserUI();
    }

    public override void OnSenceStart()
    {
        WOMMGame.Instance.ShowChooserUI(Complete);
    }

    public override void OnSenceUpdate()
    {
    }

    public void Complete() {
        mySceneManager.SetScene(new GongonVillageScene(mySceneManager));
    }
}

public class VillageScence : MyScene{
	public VillageScence (MySceneManager _mySceneManager):base(_mySceneManager){
        SceneName = "Village";
	}

    public override void OnSenceExit()
    {
        
    }

    public override void OnSenceStart ()
	{
        WOMMGame.Instance.SetMainMeatBallNormal();
        WOMMGame.Instance.SetCameraLook(WOMMGame.Instance.GetMainFigure().transform,Vector3.forward);
    }

    public override void OnSenceUpdate()
    {
    }
}

public class GongonVillageScene : VillageScence
{
    public GongonVillageScene(MySceneManager _mySceneManager) : base(_mySceneManager)
    {
        SceneName = "Gongon";
        SceneManager.LoadScene(SceneName, LoadSceneMode.Single);
    }

    public override void OnSenceStart()
    {
        base.OnSenceStart();

        WOMMGame.Instance.ShowControllUI();
        Debug.Log("貢貢村");

        WOMMGame.Instance.LetMainMoveable();
    }
}
