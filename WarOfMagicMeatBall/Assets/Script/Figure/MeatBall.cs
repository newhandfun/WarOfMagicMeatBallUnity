using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class MeatBall : Figure {

    public MeatBall(GameObject _object, FigureValue _value) : base(_object,_value)
    {
        attackNumber = 3;
        myMBBehavior = (MeatBallBehavior)myBehavior;
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

    //Material
    public override void SetUV(Vector2 _uv)
    {
        var uvs = myBehavior.GetUV();
        List<Vector2> nuvs = new List<Vector2>();
        for (int i=0; i< uvs.Length;i++) {
            nuvs.Add(_uv);
        }
        ((MeatBallBehavior)myBehavior).SetUV(nuvs);
    }

    private MeatBallSuit mySuit;

    //Suit
    public void WearSuit(MeatBallSuit _suit) {
        if (!_suit.isCommonSuit(mySuit))
        {
            mySuit = _suit;
            myMBBehavior.TakeOffSuit();
            myMBBehavior.WearSuit(_suit.GetPartsObject());
        }
    }

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
