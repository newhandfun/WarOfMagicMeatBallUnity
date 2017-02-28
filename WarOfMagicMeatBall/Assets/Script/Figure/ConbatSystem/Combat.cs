using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Combat{

	protected FigureValue myValue;
    protected AudioSource myAttackSound;

	protected GameObject hitEffect;
    protected bool isBrokable = true;

    public Combat(ref FigureValue _value){
		myValue = _value;
	}

	public void Attack(Figure _enemy){
		DecideDamage ();
		LetHurt (_enemy);
		LetBroken (_enemy);
		PlaySound (_enemy);
		PlayEffect (_enemy);
	}

    public abstract void DecideDamage();

    public abstract void LetHurt(Figure _figure);

    public abstract void LetBroken(Figure _figure);

    public abstract void PlaySound(Figure _figure);

    public abstract void PlayEffect(Figure _figure);
}
