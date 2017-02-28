using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WOMMGame {

    //GM
    GameMaster gm = null;
    public GameMaster GM {
        get { return gm; }
        set { gm = value; }
    }

    //systems
    FigureSystem myFigureSystem;
    ControllSystem myControllSystem;
    StageSystem myStageSystem;
    GameEventSystem myGameEventSystem;

    //UI
    StageUI myStageUI;
    FigureStateUI myFigureStateUI;
    ControllUI myControllUI;
    EventUI myEventUI;
    LogInUI myLoginUI;

    /// <summary>
    /// The instance.
    /// </summary>
    private static WOMMGame instance = null;
    public static WOMMGame Instance {
        get {
            if (instance == null)
            {
                instance = new WOMMGame();
                instance.Start();
            }
            return instance;
        }
    }

    //Lifecycle	
    public void Start() {

        //systems
        myControllSystem = new ControllSystem();
        myFigureSystem = new FigureSystem();
        myStageSystem = new StageSystem();
        myGameEventSystem = new GameEventSystem();

        //UI
        myControllUI = new ControllUI();
        myFigureStateUI = new FigureStateUI();
        myStageUI = new StageUI();
        myEventUI = new EventUI();
        myLoginUI = new LogInUI();

        //System Deoendance inject


        //UI Dependancy inject
        myControllUI.inject(ref myFigureSystem);
        myStageUI.inject(ref myStageSystem);
        myFigureStateUI.inject(ref myFigureSystem);
        myEventUI.inject(ref myGameEventSystem);

    }

    public void Update() {

        myControllSystem.Update();
        myFigureSystem.Update();
        myGameEventSystem.Update();
        myStageSystem.Update();

        myControllUI.Update();
        myFigureStateUI.Update();
        myStageUI.Update();
        myEventUI.Update();
    }

    #region SetCameraLook
    public void SetCameraLook(Transform _target) {
        if (Camera.main == null)
        {
            FigureFactory.instance.figureLocation = FigureFactory.FigureLocation.Other;
            FigureFactory.instance.CreateObjectToScene("Camera");
        }
        var camera = Camera.main.GetComponent<MyCamera>();
        if (camera != null) {
            camera.myTarget =_target;
        }
    }
    #endregion

    #region Login
    public void ShowLoginUI(LogInUI.LoginDelegate _login) {
        myLoginUI.Inititalize();
        myLoginUI.SetLoginButtonEvent(_login);
    }

    public void HideLoginUI() {
        myLoginUI.Hide();
    }
    #endregion

    #region Controll
    public void ShowControllUI() {
        myControllUI.Inititalize();
    }

    public void HideControllUI() {
        myControllUI.Hide();
    }
    #endregion

    #region MainFigure

    public void SetMainMeatBall() {
        myFigureSystem.ContructMeatBallAsMain(Vector3.zero);
        SetCameraLook(myFigureSystem.main.GetTrans());
    }

    public void DeleteMain(){
		
	}
    #endregion

    public void AddMoster(){
		
	}
}
