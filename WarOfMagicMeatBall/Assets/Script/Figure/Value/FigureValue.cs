using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class FigureValue {

    #region value
    [SerializeField]
	private int hp;
	[SerializeField]
    private int hpMax = 10;
	[SerializeField]
    private int speed = 100;
    [SerializeField]
    private int defence = 0;
    #endregion

    #region get/set
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
    /// <summary>
    /// defence,percent of damage by somebody(initial value is 100 = 100% Damage)
    /// </summary>
    /// <value>The defence.</value>
    public int Defence
    {
        get { return defence; }
        set
        {
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
    public float DefenceFloat
    {
        get { return (float)defence * 0.01f; }
        set { defence = (int)(value * 100f); }
    }
#endregion

    public FigureValue() {
        HP = HPMAX = Speed = 100;
    }

    public FigureValue(int _hp,int _speed) {
        HP = hpMax = _hp;
        Speed = _speed;
        Defence = 0;
    }

    #region X
    //[SerializeField]
    //protected int damage;
    //[SerializeField]
    //protected int orginDamage = 5;
    //public int Damage{
    //	get{ return damage;}
    //	set{damage = value;}
    //}
    //public int OrginDamage{
    //	get{ return orginDamage;}
    //	set{ orginDamage = value;}
    //}
    #endregion
}
