using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


[Serializable]
public class ColliderEnable  {

    [SerializeField]
    public int damage = 0;
    [SerializeField]
    public bool isBroken = true;


    [SerializeField]
    public float startTime = 0f;
    [SerializeField]
    public float endTime = 0f;
    [SerializeField]
    public float speedTimes = 1.0f;
}