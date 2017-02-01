using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WOMMGame {
	//systems
	FigureSystem myFigureSystem;
	ControllSystem myControllSystem;
	StageSystem myStageSystem;
	GameEventSystem myGameEventSystem;

	//UI
	StageUI myStageUI;
	FigureStateUI myFigureStateUI;
	ControllUI myControllUI;

	/// <summary>
	/// The instance.
	/// </summary>
	private static WOMMGame instance = null;
	public static WOMMGame Instance(){
		if (instance == null)
			instance = new WOMMGame ();
		return instance;
	}
		
	public void Initial(){
		//systems
		myControllSystem = new ControllSystem ();
		myFigureSystem = new FigureSystem ();
		myStageSystem = new StageSystem ();
		myGameEventSystem = new GameEventSystem ();

		//UI
		myControllUI = new ControllUI();
		myFigureStateUI = new FigureStateUI ();
		myStageUI = new StageUI ();

		//UI Dependancy inject
		myControllUI.inject(ref myFigureSystem);
		myStageUI.inject (ref myStageSystem);
		myFigureStateUI.inject (ref myFigureSystem);
	}

	public void AddMeatBall(){
		
	}

	public void AddMoster(){
		
	}
}
