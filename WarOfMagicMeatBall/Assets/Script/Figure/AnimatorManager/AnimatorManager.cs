using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorManager{
	//bool
	public int isIdle;
	public int isNext;
	public int isDead;
	public int isHurt;
	public int isBroken;
	public int isGround;
	public int isInterrupt;
	//float
	public int yFlyTime;
	public int xzFlyTime;
	public int vertical;
	public int horizontal;
	//int
	public int skillType;
    public int AttackType;

    public AnimatorManager(){
		//bool
		isIdle = Animator.StringToHash ("isIdle");
		isNext = Animator.StringToHash ("isNext");
		isDead = Animator.StringToHash ("isDead");
		isHurt = Animator.StringToHash ("isHurt");
		isBroken = Animator.StringToHash ("isBroken");
		isGround = Animator.StringToHash ("isGround");
		isInterrupt = Animator.StringToHash ("isInterrupt");

		//float
		yFlyTime = Animator.StringToHash("YFlyTime");
		xzFlyTime = Animator.StringToHash("XZFlyTime");
		vertical = Animator.StringToHash ("Vertical");
		horizontal = Animator.StringToHash ("Horizontal");

		//int 
		skillType= Animator.StringToHash("SkillType");
        AttackType = Animator.StringToHash("AttackType");
	}
}
