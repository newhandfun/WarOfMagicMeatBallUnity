using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FigureValue {

	//value
	[SerializeField]
	protected int hp;
	[SerializeField]
	protected int hpMax = 10;
	[SerializeField]
	protected int speed = 100;
	[SerializeField]
	protected int damage;
	[SerializeField]
	protected int orginDamage = 5;

	//get/set
	public int HP{
		get{ return hp;}
		set{ hp = Mathf.Max (value, 0);}
	}
	public int HPMAX{
		get{ return hpMax;}
		set{ hp = Mathf.Max (value, 0);}
	}
	public int Speed{
		get{ return speed;}
		set{ speed = Mathf.Min (value, 10);}
	}
	public int Damage{
		get{ return damage;}
		set{damage = value;}
	}
	public int OrginDamage{
		get{ return orginDamage;}
		set{ orginDamage = value;}
	}
}
