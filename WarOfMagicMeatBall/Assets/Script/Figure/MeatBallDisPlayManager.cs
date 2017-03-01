using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MeatBallSuit{
    public string suitName;
    public Image icon;

    private GameObject[] partsObject;

    public GameObject[] GetPartsObject() {
        if (partsObject == null) Debug.Log("NULL SUIT");
        return partsObject;
    }

    public MeatBallSuit(string _name,GameObject[] _parts,Image _icon) {
        suitName = _name;
        partsObject = _parts;
        icon = _icon;
    }

    public bool isCommonSuit(MeatBallSuit _suit) {
        if (_suit == null) return false;
        return this.suitName == _suit.suitName;
    }
}

public class MeatBallDisplayManager  {

    private static MeatBallDisplayManager instance;
    public static MeatBallDisplayManager Instance {
        get {
            if (instance == null)
                instance = new MeatBallDisplayManager();
            return instance;
        }
    }


    public MeatBallDisplayManager() {

    }

    MeatBall meatBall;
    public void SetMeatBall(MeatBall _MB) {
        meatBall = _MB;
    }

    public void SetMeatBallColor(int _index) {
        if (meatBall == null) return;
        var d = 0.0625f;
        int y = _index / 8;
        int x = _index % 8;
        Vector2 uv = new Vector2((2*x+1)*d,1f-(2*y+1)*d);
        //Debug.Log(_index + ":"+uv + "("+x+","+y+")");
        meatBall.SetUV(uv);
    }



    public void SetMeatBallSuit(string _name) {
        if (meatBall == null) return;
        if(!MeatBallSuitFactory.instance.isHavingSuit(_name))return;
        meatBall.WearSuit(MeatBallSuitFactory.instance.GetSuitByName(_name));
    }
}
