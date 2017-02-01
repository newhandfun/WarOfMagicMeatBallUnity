using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeatBallValue : FigureValue{
	
	public MeatBallValue(int _hp,int _speed,int _damage){
		HP = HPMAX = _hp;
		Speed = _speed;
		Damage = OrginDamage = _damage;
	}

}
