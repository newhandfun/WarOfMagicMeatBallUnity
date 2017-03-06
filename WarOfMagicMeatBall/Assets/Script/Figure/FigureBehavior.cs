using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FigureBehavior : Photon.MonoBehaviour {

    #region Property
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

    protected RuntimeAnimatorController normalAnimator;
    public virtual void SetMoveAnimator(RuntimeAnimatorController _AOC) { normalAnimator = _AOC; }
    #endregion

    #region ConnectionFunction
    protected PhotonView myPhotonView;
    protected bool IsNotMine() {
        return (myPhotonView.isMine==false && PhotonNetwork.connected == true);
    }
    #endregion

    #region Base Function
    public void LookAt(Vector3 _direction) {
        myTran.LookAt(_direction);
    }
    #endregion

    #region Invoke
    Dictionary<string, bool> invokeNow = new Dictionary<string, bool>();
    public enum InokeMethod
    {
        CencleAttackAnimtion
    }
    public virtual void CallInvoke(string _funtionName,float _time) {
        if (IsNotMine())
            return;
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
    #endregion

    #region Anim
    public virtual void SetAnimatorInt(int _hash, int _value) { myAnimator.SetInteger(_hash, _value); }
    public virtual void SetAnimatorBool(int _hash, bool _value) { myAnimator.SetBool(_hash, _value); }
    public virtual void SetAnimatorFloat(int _hash, float _value) { myAnimator.SetFloat(_hash, _value); }
    public void CencleAttackAnimtion() { myAnimator.SetInteger("AttackType", 0); }

    public void Moveable() {
        GetAnimator().runtimeAnimatorController = normalAnimator;
    }
    #endregion

    #region Material&UV
    public virtual Vector2[] GetUV() {
        return GetComponent<SkinnedMeshRenderer>().sharedMesh.uv;
    }

    public virtual void SetUV(List<Vector2> _nuvs) {
        GetComponent<SkinnedMeshRenderer>().sharedMesh.SetUVs(0, _nuvs);
    }
    #endregion

    #region Extend Mono Function
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
    #endregion

    #region Combat
    public DelegateKind.HittedDelegate hittedEvent;
    public DelegateKind.VoidDelegate closeInvincible;

    public void Hitted(int _damage,bool _isBroken) {
        if(hittedEvent!=null) hittedEvent(_damage,_isBroken);
    }

    public void Invincible(float _times) {
        StartCoroutine(InvincibleTimer(_times));
    }
    IEnumerator InvincibleTimer(float _times) {
        yield return new WaitForSeconds(_times);
        if(closeInvincible!=null)closeInvincible();
    }
    #endregion

    //State
    public virtual void Awake()
    {
        myObject = gameObject;
        myTran = transform;
        selfColider = GetComponent<BoxCollider>();
        myAnimator = GetComponent<Animator>();


        normalAnimator = Resources.Load("Animator/Figure") as RuntimeAnimatorController;
        myPhotonView = GetComponent<PhotonView>();
    }

    public virtual void Update()
    {

    }
}
