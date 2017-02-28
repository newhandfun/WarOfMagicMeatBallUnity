using UnityEngine;
using System.Collections;


public abstract class Figure {

    protected FigureValue myValue;
    protected AnimatorManager myAmanager = new AnimatorManager();

    //MonoBehavior
    protected FigureBehavior myBehavior;
    public virtual GameObject GetObject() { return myBehavior.GetObject(); }
    public virtual Transform GetTrans() { return myBehavior.GetTrans(); }
    //public virtual BoxCollider GetWeaponColider() { return myBehavior.GetWeaponColider(); }
    //public virtual BoxCollider GetSelfColider() { return myBehavior.GetSelfColider(); }
    //public virtual Animator GetAnim() { return myBehavior.GetAnimator(); }

    //Animation
    protected static AnimatorManager myAnimManager = new AnimatorManager();
    protected int attackNumber = 1;
    public virtual int GetAttackNumber(){ return attackNumber; }
    public virtual void SetAttackNumber(int _number) { attackNumber = _number; }

    //system
    protected Combat myCombat;

    public Figure() { }

    public Figure(GameObject _object,FigureValue _value) {
        myBehavior = _object.GetComponent<FigureBehavior>();
        if (myBehavior == null)
            Debug.Log("沒有FigureBehavior，多數函式將無法運作!");
        myBehavior.Awake();
        myValue = _value;
    }

    public virtual void SetValue(FigureValue _value) {
        myValue = _value;
    }

    //移動
    public abstract void MoveTo(float _x, float _z);
    public abstract void MoveFinish();

    //攻擊
    public virtual void NormalAttack() {
        AnimAttack();
    }
    public virtual void CencleAttack() {
        AnimCencleAttack();
    }

    //AI
    // public abstract void setAI();

    //技能
    public virtual void SetSkill() {
    }
    public virtual void GetSkill() {
    }
    public abstract void UseSkill(int index);

    //動作
    public virtual void AnimWalk(float _value) {
        myBehavior.GetAnimator().SetFloat(myAnimManager.vertical, _value);
    }
    public virtual void AnimAttack() {
        myBehavior.GetAnimator().SetInteger(myAnimManager.AttackType,this.attackNumber);
        myBehavior.CallInvoke(FigureBehavior.InokeMethod.CencleAttackAnimtion.ToString(),0.2f);
    }
    public virtual void AnimCencleAttack()
    {
        myBehavior.GetAnimator().SetInteger(myAnimManager.AttackType, 0);
    }

    public abstract void Start();

    public abstract void Update();

    public abstract void Destory();
}