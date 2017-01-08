using UnityEngine;
using System.Collections;

public class Figure : MonoBehaviour {

	[SerializeField]
	private int hp;
	[SerializeField]
	private int hpMax = 10;
	[SerializeField]
	private int speed = 100;
	[SerializeField]
	private int damage;
	[SerializeField]
	private int orginDamage = 5;

	//decide damage <0 or not
	public bool isDamageForbid = true;

	//get/set
	public int HP{
		get{ return hp;}
		set{ HP = Mathf.Min (value, 0);}
	}
	public int Speed{
		get{ return speed;}
		set{ speed = Mathf.Min (value, 0);}
	}
	public int Damage{
		get{ return damage;}
		set{ damage = isDamageForbid? 
				Mathf.Min (value, 0):value;}
	}

	//Initial
	public void InitialHP(){hp = hpMax;}
	public void InitialSpeed(){speed = 100;}
	public void InitialDamage(){damage = orginDamage;}
	public void InitialAll(){
		InitialHP ();
		InitialDamage ();
		InitialSpeed ();
	}
}