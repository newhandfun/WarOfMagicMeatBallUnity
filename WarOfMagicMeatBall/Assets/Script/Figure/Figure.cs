using UnityEngine;
using System.Collections;


public class Figure{

	public FigureValue myValue;
	public AnimatorManager _amanager;

	//Component
	public GameObject myObject;
	public Transform myTran;

	//Animation
	public Animator myAnim;
	public AnimatorManager myAnimManager;

	//system
	public Combat myCombat;


	public Figure(){}

	public Figure(GameObject _object,int _hp,int _speed,int _damage){
		myObject = _object;
		myValue = new MosterValue (_hp,_speed,_damage);
		myAnim = myObject.GetComponent<Animator> ();
		myTran = myObject.GetComponent<Transform> ();
	}

	public void AttackAnimation(){
		myAnim.SetBool ("Attack",true);
	}

	public void Start(){
		
	}

	public void Update(){
		
	}

	public void Destory(){
		
	}
}