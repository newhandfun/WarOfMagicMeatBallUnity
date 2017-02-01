using UnityEngine;
using System.Collections;

public class MeatBall : Figure {

	MeatBallSuit mySuit;

	public void SetSuit(MeatBallSuit _suit){
		mySuit = _suit;
	}

	public void LookAtDistination(Vector3 _direction){
		myTran.forward = _direction;
	}
}
