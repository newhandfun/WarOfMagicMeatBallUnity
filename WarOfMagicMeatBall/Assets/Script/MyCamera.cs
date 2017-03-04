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
    private Transform myTarget;
    private Vector3 direct;

    private Vector3 myDistance = Vector3.zero;
    private Vector3 myLookAt;

    void Start() {
        myCamera = GetComponent<Camera>();
        myTrans = GetComponent<Transform>();
    }

    void Update() {
        if (myTarget) {

            myTrans.position = Vector3.Lerp(myTrans.position,NewCameraPosition(),damping*Time.deltaTime);

            //myLookAt = Vector3.Lerp(myLookAt,NewLookTarget(),damping);

            //myTrans.LookAt(myLookAt);
        }
    }

    public void SetCameraTarget(Transform _trans,Vector3 _direct) {
        myTarget = _trans;
        direct = _direct;
        myTrans.position = NewCameraPosition();
        myLookAt = NewLookTarget();
        myTrans.LookAt(myLookAt);
    }

    private Vector3 NewLookTarget() {
        Vector3 posi = new Vector3();
        posi.x = myTarget.position.x;
        posi.y = myTarget.position.y  + 0.75f;
        posi.z = myTarget.position.z;
        return  posi;
    }

    private Vector3 NewCameraPosition() {
        Vector3 posi = new Vector3();
        posi.x = myTarget.position.x;
        posi.y = myTarget.position.y + distance + 0.75f;
        posi.z = myTarget.position.z + distance;
        return Quaternion.Euler(direct)*posi;
    }
}
