using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MosterValue : FigureValue {

	public MosterValue(int _hp,int _speed,int _damage){
		HP = HPMAX = _hp;
		Speed = _speed;
		Damage = OrginDamage = _damage;
	}

	private int defence = 0;
	/// <summary>
	/// defence,percent of damage by somebody(initial value is 100 = 100% Damage)
	/// </summary>
	/// <value>The defence.</value>
	public int Defence{
		get{return defence;}
		set{ 
			if (value < -100)
				value = -100;
			else if (value > 100)
				value = 100;
			defence = value;
		}
	}
	/// <summary>
	/// defence,mutiple of damage by somebody(initial value is 1f = 100% Damage)
	/// </summary>
	/// <value>The defence float.</value>
	public float DefenceFloat{
		get{return (float)defence * 0.01f; }
		set{defence = (int)(value*100f);}
	}
}
