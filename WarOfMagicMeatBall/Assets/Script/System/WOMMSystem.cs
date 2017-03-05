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

	public GameObject ContructFigure(string _name,Vector3 _position,Quaternion _rotation){
        return FigureFactory.instance.CreateLocalObjectToScene(_name,_position,_rotation);
	}
    public void ContructFigureAsMain(string _name, Vector3 _position, Quaternion _rotation)
    {
        FigureFactory.instance.CreateLocalObjectToScene(_name, _position, _rotation);
    }

    public void ContructMeatBallAsMain(Vector3 _position,Quaternion _rotaion)
    {
        if (mainMeatBall == null)
        {
            mainMeatBall = FigureFactory.instance.CreateMeatBallToScene(_position,_rotaion);
            main = (new MeatBall(mainMeatBall,new MeatBallValue(100,100,10)))as Figure;
            GameObject.DontDestroyOnLoad(mainMeatBall);
        }
    }

    public void ContructMeatBallAsMain(string _name,Vector3 _position, Quaternion _rotaion)
    {
        if (mainMeatBall == null)
        {
            mainMeatBall = FigureFactory.instance.CreateMeatBallToScene(_name, _position, _rotaion);
            main = (new MeatBall(mainMeatBall, new MeatBallValue(100, 100, 10))) as Figure;
            GameObject.DontDestroyOnLoad(main.GetObject());
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
	
