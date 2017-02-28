using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour {

	MySceneManager mySceneManager = new MySceneManager ();

    ResrouceFactory myResrouseFactory = new ResrouceFactory();
    FigureFactory myFigureFactory = new FigureFactory();
    UIFactory myUIFactory = new UIFactory();


    void Awake(){
        DontDestroyOnLoad(this.gameObject);
      
        mySceneManager = new MySceneManager();
		mySceneManager.OnAwake ();
	}

	void Start(){
		mySceneManager.OnStart ();
	}

	void Update(){
		mySceneManager.OnUpdate ();
        WOMMGame.Instance.Update();
    }
}
