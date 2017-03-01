﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FigureBehavior : MonoBehaviour {

    //Component
    protected GameObject myObject;
    public virtual GameObject GetObject() { return myObject; }
    protected Transform myTran;
    public virtual Transform GetTrans() { if (myTran == null) myTran = transform; return myTran; }
    //optional
    [SerializeField]
    protected BoxCollider weaponColider;
    public virtual BoxCollider GetWeaponColider() { return weaponColider; }
    [SerializeField]
    protected BoxCollider selfColider;
    public virtual BoxCollider GetSelfColider() { return selfColider; }
    protected Rigidbody selfRigid;
    public virtual Rigidbody GetRigidBody() { return selfRigid; }

    //Animator
    [SerializeField]
    protected Animator myAnimator;
    public virtual Animator GetAnimator() { return myAnimator; }
    public virtual void SetAnimator(Animator _anim) { myAnimator = _anim; }
    public virtual void SetAnimatorInt(int _hash,int _value) { myAnimator.SetInteger(_hash,_value); }
    public virtual void SetAnimatorBool(int _hash, bool _value) { myAnimator.SetBool(_hash, _value);  }
    public virtual void SetAnimatorFloat(int _hash, float _value) { myAnimator.SetFloat(_hash, _value); }


    //Base Function
    public void LookAt(Vector3 _direction) {
        myTran.LookAt(_direction);
    }

    //State Delegate
    public void Awake() {
        myObject = gameObject;
        myTran = transform;
        selfColider = GetComponent<BoxCollider>();
        myAnimator = GetComponent<Animator>();

        InitialInvoke();
    }

    public virtual void Update() {

    }

    //Invoke 
    Dictionary<string, bool> invokeNow = new Dictionary<string, bool>();
    public enum InokeMethod
    {
        CencleAttackAnimtion
    }
    protected virtual void InitialInvoke() {
        
    }
    public virtual void CallInvoke(string _funtionName,float _time) {
        if (!invokeNow.ContainsKey(_funtionName))
        {
            invokeNow.Add(_funtionName, false);
        }

        if (invokeNow[_funtionName])
        {
            invokeNow[_funtionName] = false;
            CancelInvoke(_funtionName);
        }
        else
            invokeNow[_funtionName] = true;

        Invoke(_funtionName,_time);
    }

    //Anim
    public void CencleAttackAnimtion() { myAnimator.SetInteger("AttackType", 0); }

    //Material
    public virtual Vector2[] GetUV() {
        return GetComponent<SkinnedMeshRenderer>().sharedMesh.uv;
    }

    public virtual void SetUV(List<Vector2> _nuvs) {
        GetComponent<SkinnedMeshRenderer>().sharedMesh.SetUVs(0, _nuvs);
    }

    //Find
    protected Transform FindObjectInChild(Transform _trans, string _name)
    {
        foreach (Transform child in _trans)
        {
            if (child.name == _name)
                return child;
            var result = FindObjectInChild(child, _name);
            if (result != null)
                return result;
        }
        return null;
    }
}
