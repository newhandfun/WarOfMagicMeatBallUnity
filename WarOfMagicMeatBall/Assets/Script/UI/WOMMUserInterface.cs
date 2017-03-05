using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// WOMM UI
/// </summary>
[SerializeField]public abstract class WOMMUserInterface  {

    protected WOMMGame myGame;
	protected GameObject myRootUI;
	protected bool isActive = true;

	public WOMMUserInterface(){}

	public WOMMUserInterface(WOMMGame _game){
		myGame = _game;
	}

	public virtual bool Show(){
        if (myRootUI == null) return false;
		myRootUI.SetActive (true);
		isActive = true;
        return true;
	}

	public virtual bool Hide(){
        if (myRootUI == null) return false;
        myRootUI.SetActive (false);
        return true;
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
	[SerializeField] MyButton attackInput;
	[SerializeField] JoystickController movementInput;
	[SerializeField] MyButton jumpInput;
	[SerializeField] MyButton[] skillInput;


	public void inject(ref FigureSystem _figure){
		myFigureSystem = _figure;
	}

	public override void Inititalize ()
	{
        UIFactory.instance.refreshCanvas = UIFactory.RefreshCanvasType.usuallyRefreshCanvas;

        //LoadUIformResource
        if (myRootUI == null) {
            myRootUI = UIFactory.instance.CreateLocalObjectToScene("Base");
            myRootUI.name = "Controller";
            RectTransform rect = myRootUI.GetComponent<RectTransform>();
            rect.sizeDelta = Vector3.zero;
            rect.offsetMin = rect.offsetMax = Vector3.zero;
        }

        //move on controllor drag
        if (movementInput == null)
        {
            GameObject moveObj = UIFactory.instance.CreateLocalObjectToScene("Movement");
            RectTransform moveRect = moveObj.GetComponent<RectTransform>();
            moveRect.SetParent(myRootUI.transform);
            moveRect.sizeDelta = Vector3.zero;
            moveRect.offsetMin = moveRect.offsetMax = Vector3.zero;
            movementInput = moveObj.GetComponentInChildren<JoystickController>();
            movementInput.OnStart();
        }


        //attack on click
        if (attackInput == null)
        {
            GameObject attackObj = UIFactory.instance.CreateLocalObjectToScene("Attackion");
            RectTransform attackRect = attackObj.GetComponent<RectTransform>();
            attackRect.SetParent(myRootUI.transform);
            attackRect.sizeDelta = Vector3.zero;
            attackRect.offsetMin = attackRect.offsetMax = Vector3.zero;
            attackInput = attackObj.GetComponentInChildren<MyButton>();
        }

        if (myFigureSystem.main != null)
        {
            movementInput.myOnDragDele = myFigureSystem.main.MoveTo;
            movementInput.myOnExitDele = myFigureSystem.main.MoveTo;
            attackInput.onButtonDownDele = myFigureSystem.main.NormalAttack;
            //attackInput.onButtonUpDele = myFigureSystem.main.CencleAttack;
        }
        else
            Debug.Log("沒有主角無法使用控制UI");

        
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
    GameEventSystem myGameEventSystem;

    public void inject(ref GameEventSystem _ges) {
        myGameEventSystem = _ges;
    }
}

[SerializeField]
public class LogInUI : WOMMUserInterface {

    Button loginButton;

    MeatBallChooser choser;

    public override void Inititalize()
    {
        if (myRootUI == null) {
            myRootUI = UIFactory.instance.CreateLocalObjectToScene("Base",Vector3.zero);
            myRootUI.name = "LoginUI";
        }
    }

    public void SetLoginButtonEvent(DelegateKind.VoidDelegate _login) {
        if (loginButton == null)
        {
            var loginObj = (UIFactory.instance.CreateLocalObjectToScene("LoginButton"));
            loginObj.transform.SetParent(myRootUI.transform);
            loginButton = loginObj.GetComponentInChildren<MyButton>();
        }
        else myRootUI.SetActive(true);
        loginButton.onClick.AddListener(() => _login());
    }
}

public class ChooseUI : WOMMUserInterface{

    MeatBall meatBall = null;
    MeatBallChooser chooser = null;
    MyButton nextButton = null;

    public override void Inititalize()
    {
        if (myRootUI == null) {
            myRootUI = UIFactory.instance.CreateLocalObjectToScene("Chooser") as GameObject;
        }
        myRootUI.SetActive(true);

        InitialChooserUI();
    }

    public void SetMeatBall(MeatBall _MB) {
        if (_MB != null)
        {
            meatBall = _MB;
            chooser.chooseColor = meatBall.SetMeatBallColor;
            chooser.chooseSuit = meatBall.SetMeatBallSuit;
        }
        else
            Debug.Log("No MeatBall to pick color/suit,UI will no Work");
    }

    public void InitialChooserUI() {
        chooser = myRootUI.GetComponent<MeatBallChooser>();
        nextButton = myRootUI.GetComponentInChildren<MyButton>();
    }

    public void SetNextEvent(DelegateKind.VoidDelegate _next) {
        nextButton.onClick.AddListener(() => _next());
    }

}