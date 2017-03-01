using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCamera : MonoBehaviour {

    Camera myCamera;

    Transform myTrans;

    [SerializeField]
    public float distance = 10f;
    [SerializeField]
    public float damping = 3f;
    [SerializeField]
    public Transform myTarget;


    private Vector3 myDistance = Vector3.zero;

    void Start() {
        myCamera = GetComponent<Camera>();
        myTrans = GetComponent<Transform>();
    }

    void Update() {
        if (myTarget) {
            myDistance.y = distance + 0.75f;
            myDistance.z = distance;
            myTrans.position = Vector3.Lerp(myTrans.position,myTarget.position + myDistance,damping*Time.deltaTime);
        }
    }
}
