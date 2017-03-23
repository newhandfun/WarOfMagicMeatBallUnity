using UnityEngine;
using System.Collections;


public abstract class Figure {

    //Self Property
    protected FigureValue myValue;
    protected AnimatorManager myAmanager = new AnimatorManager();

    //MonoBehavior
    protected FigureBehavior myBehavior;
    public virtual GameObject GetObject() { return myBehavior.GetObject(); }
    public virtual void SetObject(GameObject _GO) { myBehavior = _GO.GetComponent<FigureBehavior>(); }
    public virtual Transform GetTrans() { return myBehavior.GetTrans(); }

    //Animation
    protected static AnimatorManager myAnimManager = new AnimatorManager();
    protected int attackNumber = 1;
    public virtual int GetAttackNumber(){ return attackNumber; }
    public virtual void SetAttackNumber(int _number) { attackNumber = _number; }

    //extra action
    protected DefenceSystem myDefence;
    protected AttactionData myAttactionData;

    public Figure() { }

    public Figure(GameObject _object,FigureValue _value) {
        SetBehavior(_object);
        SetValue(_value);
        myDefence = new DefenceSystem(ref myValue);
    }

    public virtual void SetBehavior(GameObject _object) {
        myBehavior = _object.GetComponent<FigureBehavior>();
        if (myBehavior == null)
        {
            Debug.Log("沒有FigureBehavior，多數函式將無法運作!");
            return;
        }
        //Defence
        myBehavior.Awake();
        myBehavior.hittedEvent = Hitted;
        myBehavior.closeInvincible = Vincible;
    }

    public virtual void SetAttactionData(string _ADataName) {
        myAttactionData = ScriptableObjectFactory.instance.GetAttackDataByName(_ADataName);
        if (myAttactionData == null) myAttactionData = new AttactionData();
    }

    public virtual void SetValue(FigureValue _value) {
        myValue = _value;
    }

    //取值
    public virtual int GetHP() {
        return myValue.HP;
    }
    public virtual int GetMapHP() {
        return myValue.HPMAX;
    }
    public virtual int GetSpeed() {
        return myValue.Speed;
    }
    public virtual int GetDefence() {
        return myValue.Defence;
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

    //被攻擊
    public virtual void Hitted(int _damage,bool _isBroken) {
        if (myDefence == null) return;
        myDefence.Hitten(_damage,_isBroken);
    }
    public virtual void Invincible() {
        if (myDefence == null) return;
        myDefence.IsInvincible = true;
    }
    public virtual void Vincible() {
        if (myDefence == null) return;
        myDefence.IsInvincible = false;
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

    //材質
    public virtual void SetUV(Vector2 _uv) {
    }

    public abstract void Start();

    public abstract void Update();

    public abstract void Destory();
}