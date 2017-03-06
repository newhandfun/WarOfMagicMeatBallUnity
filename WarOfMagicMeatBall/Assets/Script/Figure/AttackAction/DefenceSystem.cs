using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenceSystem
{

    protected FigureValue myValue;
    protected AudioSource myHittedSound;

    protected GameObject hitEffect;
    protected bool isBrokable = true;
    protected bool isInvincible = false;

    public DelegateKind.VoidDelegate hurt;
    public DelegateKind.VoidDelegate broken;

    #region getter/setter
    public bool IsBrokable {
        get { return isBrokable; }
        set { isBrokable = value; }
    }
    public bool IsInvincible {
        get { return isInvincible; }
        set { isInvincible = value; }
    }
    #endregion

    public DefenceSystem(ref FigureValue _value){
		myValue = _value;
	}

	public void Hitten(int _damage,bool _isBroken){
		BeHurt (_damage);
        BeBroken(_isBroken);
		PlaySound ();
		PlayEffect ();
	}

    public virtual void BeHurt(int _damage) {
        if(!isInvincible)
            myValue.HP -= _damage;
    }

    public virtual void BeBroken(bool _isBroken) {
        if (_isBroken)
        {
            if (isBrokable && broken != null)
                broken();
            else if (hurt != null)
                hurt();
            else
                Debug.Log("被擊委派沒有被指派!");
        }
        else if (!isBrokable)
            if (hurt != null)
                hurt();
            else
                Debug.Log("被擊委派沒有被指派!");

    }

    public virtual void PlaySound() {

    }

    public virtual void PlayEffect() {

    }
}
