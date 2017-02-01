using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Combat{

	protected FigureValue myValue;

	protected AudioSource myAttackSound;

	protected bool isBroken = true;

	protected GameObject hitEffect;

	public Combat(ref FigureValue _value){
		myValue = _value;
	}

	public void Attack(Figure _figure){
		DecideDamage ();
		LetHurt (_figure);
		LetBroken (_figure);
		PlaySound (_figure);
		PlayEffect (_figure);
	}
		
	public virtual void DecideDamage(){
		myValue.Damage = myValue.OrginDamage;
	}

	public virtual void LetHurt(Figure _figure){
		myValue.Damage = myValue.OrginDamage;
	}

	public virtual void LetBroken(Figure _figure){
		if(isBroken)
			_figure.myAnim.SetBool (_figure.myAnimManager.isBroken,true);
	}

	public virtual void PlaySound(Figure _figure){
		myAttackSound.Play ();
	}

	public virtual void PlayEffect(Figure _figure){
		GameObject.Instantiate (hitEffect,_figure.myTran.position,_figure.myTran.rotation);
	}
}
