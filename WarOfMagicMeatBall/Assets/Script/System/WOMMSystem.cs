using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WOMMSystem  {

	protected WOMMGame myWOMMGame;
	public WOMMSystem(){
		myWOMMGame = WOMMGame.Instance;
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
    public GameObject mainMeatBall;

    public void Inject() {

    }

	public void Contruct(string _name,Vector3 _position){
		
	}

    public void ContructMeatBallAsMain(Vector3 _position)
    {
        if (mainMeatBall == null)
        {
            mainMeatBall = FigureFactory.instance.CreateMeatBallToScene();
            main = (new MeatBall(mainMeatBall,new MeatBallValue(100,100,10)))as Figure;

            
        }
    }
}

public class ControllSystem : WOMMSystem{

	//float myVertical = 0f;
	//float myHorizontal = 0f;

	Quaternion myRotation;
    FigureSystem myFigure;

	public override void Initial (){}

	public override void Start (){}

	public override void Update (){}

	public void InputDirection(float _x,float _y){
		
	}

    public void Inject(ref FigureSystem _figure)
    {
        myFigure =_figure;
    }
}

public class StageSystem : WOMMSystem{

    FigureSystem myFigure;
    

}

public class GameEventSystem : WOMMSystem{

    StageSystem myStage;

    //game event delegate
    public delegate void GameEvent();
}

public class FigureBuilderSystem : WOMMSystem{
	public void Build(FigureBuilder _build){
		_build.AddUnityEvent ();
		_build.AddFigureInSystem (myWOMMGame);
		_build.SetFigureValue ();
		_build.AddAI ();
	}
}
	
