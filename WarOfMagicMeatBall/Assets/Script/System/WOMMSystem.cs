using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WOMMSystem  {

	protected WOMMGame myWOMMGame;
	public WOMMSystem(){
		myWOMMGame = WOMMGame.Instance();
		Initial ();
	}

	/// <summary>
	/// Initial this system after input a WOMMGame.
	/// </summary>
	public virtual void Initial(){}

	/// <summary>
	/// OnStart
	/// </summary>
	public virtual void Start (){}

	/// <summary>
	/// OnUpdate
	/// </summary>
	public virtual void Update(){}
}

public class FigureSystem : WOMMSystem{

	public Figure main;

	public void Contruct(Vector3 _position){
		
	}
}

public class ControllSystem : WOMMSystem{

	//float myVertical = 0f;
	//float myHorizontal = 0f;

	Quaternion myRotation;

	public override void Initial (){}

	public override void Start (){}

	public override void Update (){}

	public void InputDirection(float _x,float _y){
		
	}
}

public class StageSystem : WOMMSystem{
	
}

public class GameEventSystem : WOMMSystem{
	
}

public class FigureBuilderSystem : WOMMSystem{
	public void Build(FigureBuilder _build){
		_build.AddUnityEvent ();
		_build.AddFigureInSystem (myWOMMGame);
		_build.SetFigureValue ();
		_build.AddAI ();
	}
}
	
