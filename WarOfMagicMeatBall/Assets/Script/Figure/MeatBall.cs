using UnityEngine;
using System.Collections;
using System;

public class MeatBall : Figure {

	MeatBallSuit mySuit;

    public MeatBall(GameObject _object, FigureValue _value) : base(_object,_value)
    {
        attackNumber = 3;
    }

    public void SetSuit(MeatBallSuit _suit){
		mySuit = _suit;
	}

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
