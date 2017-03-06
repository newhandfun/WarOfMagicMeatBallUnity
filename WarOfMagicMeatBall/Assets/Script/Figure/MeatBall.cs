using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class MeatBall : Figure {

    public MeatBall(GameObject _object, FigureValue _value, string _ADataName) : base(_object,_value,_ADataName)
    {
        attackNumber = 3;
        myMBBehavior = (MeatBallBehavior)myBehavior;

        SetMeatBallColor(15);
    }

    private MeatBallBehavior myMBBehavior;

    public override void MoveTo(float _x, float _z)
    {
        var distance = Mathf.Sqrt(_x * _x + _z * _z);
        myBehavior.LookAt(new Vector3(GetTrans().position.x - _x, GetTrans().position.y, GetTrans().position.z - _z));
        AnimWalk(distance);
    }
    public override void MoveFinish()
    {
        AnimWalk(0f);
    }

    public override void UseSkill(int index)
    {
        throw new NotImplementedException();
    }

    #region Material&UV
    public override void SetUV(Vector2 _uv)
    {
        var uvs = myBehavior.GetUV();
        List<Vector2> nuvs = new List<Vector2>();
        for (int i=0; i< uvs.Length;i++) {
            nuvs.Add(_uv);
        }
        ((MeatBallBehavior)myBehavior).SetUV(nuvs);
    }

    public void SetMeatBallColor(int _index)
    {
        if (myBehavior == null) return;
        var d = 0.0625f;
        int y = _index / 8;
        int x = _index % 8;
        Vector2 uv = new Vector2((2 * x + 1) * d, 1f - (2 * y + 1) * d);
        //Debug.Log(_index + ":"+uv + "("+x+","+y+")");
        this.SetUV(uv);
    }
    #endregion

    #region Suit
    private MeatBallSuit mySuit;

    //Suit
    public void SetMeatBallSuit(string _name)
    {
        if (myBehavior == null) return;
        if (!MeatBallSuitFactory.instance.isHavingSuit(_name))
            return;
        WearSuit(MeatBallSuitFactory.instance.GetSuitByName(_name));
    }

    public void WearSuit(MeatBallSuit _suit) {
        if (_suit.isCommonSuit(mySuit))
            return;
        if (_suit != null)
            TakeOffSuit();
        mySuit = _suit;
        mySuit.Show();
        myMBBehavior.DressUp(mySuit.GetPartsObject());
    }

    public void TakeOffSuit() {
        if (mySuit != null) {
            mySuit.TakeOff();
            mySuit = null;
        }
    }
    #endregion


    #region Animator
    public void StandByAnimator() {
        myMBBehavior.StandByAnimator();
    }

    public void NoramlAnimator() {
        myMBBehavior.NormalAnimator();
    }

    #endregion
    public override void Start()
    {
    }

    public override void Update()
    {
    }

    public override void Destory()
    {
    }

    public override void NormalAttack()
    {
        base.NormalAttack();
    }

    public override void CencleAttack()
    {
        base.CencleAttack();
    }
}
