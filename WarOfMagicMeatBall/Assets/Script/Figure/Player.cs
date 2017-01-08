using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	private float verticalMovement;
	private float horizontalMovement;

	void Move(){
		verticalMovement = Input.GetAxis ();
	}
}
