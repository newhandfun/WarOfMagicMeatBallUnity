using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptableObjectFactory : IObjectFactory
{
    public static ScriptableObjectFactory instance = new ScriptableObjectFactory();


    public AttactionData GetAttackDataByName(string _name) {
        return LoadObject(_name) as AttactionData;
    }

    public override GameObject Instantiate(string _name, Vector3 _position, Quaternion _rotation)
    {
        throw new NotImplementedException();
    }
}
