using UnityEngine;
using System.Collections;

public class Player : Figure {


	public void Rotation(Vector3 _direction){
		tran.forward = _direction;
	}
}
