using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// WOMM UI
/// </summary>
public abstract class WOMMUserInterface : MonoBehaviour {
	protected WOMMGame myGame;
	protected GameObject myRootUI;
	protected bool isActive = true;

	public WOMMUserInterface(){}

	public WOMMUserInterface(WOMMGame _game){
		myGame = _game;
	}

	public virtual void Show(){
		myRootUI.SetActive (true);
		isActive = true;
	}

	public virtual void Hide(){
		myRootUI.SetActive (false);
		isActive = false;
	}

	public virtual void Inititalize(){}
	public virtual void Release(){}
	public virtual void Update(){}
}

/// <summary>
/// Controll.
/// include main character's Movement,attack and skill
/// </summary>
[SerializeField]public class ControllUI : WOMMUserInterface{

	FigureSystem myFigureSystem;

	//property
	[SerializeField] Button attackInput;
	[SerializeField] JoystickController movementInput;
	[SerializeField] Button jumpInput;
	[SerializeField] Button[] skillInput;


	public void inject(ref FigureSystem _figure){
		myFigureSystem = _figure;
	}

	public override void Inititalize ()
	{
		
	}
}

/// <summary>
/// Figure state UI
/// display state(hp,photo) of figure
/// </summary>
[SerializeField]public class FigureStateUI : WOMMUserInterface{

	FigureSystem myFigureSystem;

	public void inject(ref FigureSystem _figure){
		myFigureSystem = _figure;
	}
}

/// <summary>
/// Stage UI
/// show information of stage
/// </summary>
[SerializeField]public class StageUI : WOMMUserInterface{
	StageSystem myStage;

	public void inject(ref StageSystem _stage){
		myStage = _stage;
	}
}

/// <summary>
/// Event UI
/// No usage now
/// </summary>
[SerializeField]public class EventUI : WOMMUserInterface{
	
}