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
    ChooseUI myMeatBallPickerUI;

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
        myMeatBallPickerUI = new ChooseUI();

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

    #region Camera
    public void SetCameraLook(Transform _target,Vector3 _direct) {
        if (Camera.main == null)
        {
            FigureFactory.instance.figureLocation = FigureFactory.FigureLocation.Other;
            FigureFactory.instance.CreateLocalObjectToScene("Camera");
        }
        else if (Camera.main.GetComponent<MyCamera>() == null){
            Camera.main.gameObject.AddComponent<MyCamera>();
        }
        GameObject.DontDestroyOnLoad(Camera.main);
        var camera = Camera.main.GetComponent<MyCamera>();
        if (camera != null) {
            camera.SetCameraTarget(_target,_direct);
        }
    }
    public void DestroyCamera() {
        if (Camera.main != null) {
            GameObject.Destroy(Camera.main);    
        }
    }
    #endregion

    #region Login
    /// <summary>
    /// Call By LoginScene,link login event and UI;
    /// </summary>
    /// <param name="_login"></param>
    public void ShowLoginUI(DelegateKind.VoidDelegate _login) {
        if (!myLoginUI.Show())
        {
            myLoginUI.Inititalize();
            myLoginUI.SetLoginButtonEvent(_login);
        }
    }

    public void HideLoginUI() {
        myLoginUI.Hide();
    }
    #endregion

    #region Chooser
    public void ShowChooserUI(DelegateKind.VoidDelegate _next) {
        if (myMeatBallPickerUI.Show())
            return;
        myMeatBallPickerUI.Inititalize();
        myMeatBallPickerUI.Show();
        myMeatBallPickerUI.SetMeatBall((MeatBall)myFigureSystem.main);
        myMeatBallPickerUI.SetNextEvent(_next);
    }
    public void HideChooserUI() {
        myMeatBallPickerUI.Hide();
    }
    #endregion

    #region Controll
    public void ShowControllUI() {
        if (!myControllUI.Show())
        {
            myControllUI.Inititalize();
        }
    }

    public void HideControllUI() {
        myControllUI.Hide();
    }

    #endregion

    #region MainFigure

    public void SetMainMeatBall(Vector3 _position) {
        myFigureSystem.ContructMeatBallAsMain(_position,Quaternion.Euler(Vector3.zero));
        //SetCameraLook(myFigureSystem.main.GetTrans());
    }

    public GameObject GetMainFigure() {
        return myFigureSystem.main.GetObject();
    }

    public void DeleteMain(){
		
	}

    public void SetMainMeatBallStandBy() {
        if (myFigureSystem.main as MeatBall != null)
        {
            ((MeatBall)myFigureSystem.main).StandByAnimator();
        }
    }
    public void SetMainMeatBallNormal() {
        if (myFigureSystem.main as MeatBall != null)
        {
            ((MeatBall)myFigureSystem.main).NoramlAnimator();
        }
    }

    public void LetMainMoveable() {
    }
    #endregion

    public void AddMoster(){
		
	}
}
