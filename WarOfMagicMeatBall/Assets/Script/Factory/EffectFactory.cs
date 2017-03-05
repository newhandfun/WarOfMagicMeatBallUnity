using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EffectLocation
{
    MeatBallSuit,
    Stage,
    Moster
}

public class EffectFactory : IInstantiateFactory
{
    public static EffectFactory instance = new EffectFactory();

    EffectLocation location = EffectLocation.MeatBallSuit;

    public GameObject CreateConnectionObject(string _name,EffectLocation _location,
        Vector3 _position,Quaternion _rotation) {

        _name = ResrouceFactory.EffectLocation + "/"+  _location.ToString() +"/"+ _name;

        return CreateConnectionObjectToScene(_name,_position,_rotation);
    }
    
}
