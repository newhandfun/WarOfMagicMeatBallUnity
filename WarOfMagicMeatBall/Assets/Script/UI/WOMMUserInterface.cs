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
            myRootUI = UIFactory.instance.CreateObjectToScene("Base");
            myRootUI.name = "Controller";
            RectTransform rect = myRootUI.GetComponent<RectTransform>();
            rect.sizeDelta = Vector3.zero;
            rect.offsetMin = rect.offsetMax = Vector3.zero;
        }

        //move on controllor drag
        if (movementInput == null)
        {
            GameObject moveObj = UIFactory.instance.CreateObjectToScene("Movement");
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
            GameObject attackObj = UIFactory.instance.CreateObjectToScene("Attackion");
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
    public delegate void LoginDelegate();

    public void SetLoginButtonEvent(LoginDelegate _login) {
        if (myRootUI == null) myRootUI = (UIFactory.instance.CreateObjectToScene("LoginButton"));
        else UIFactory.instance.Instantiate(myRootUI, Vector3.zero);
        if (loginButton == null)
            loginButton = myRootUI.GetComponentInChildren<Button>();
        loginButton.onClick.AddListener(() => _login());
    }
}