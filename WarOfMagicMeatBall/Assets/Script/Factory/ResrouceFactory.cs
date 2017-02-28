using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResrouceFactory  :IObjectFactory {

    //Resource
    public static string UILocation = @"Prefab/UI/";
    public static string FigureLocation = @"Prefab/Figure/";

    public override UnityEngine.Object LoadObject(string _name)
    {
        return Resources.Load(_name);
    }

    //public override Object CreateObjectToScene(Object _object)
    //{
    //    return UnityEngine.Object.Instantiate(_object) as GameObject;
    //}

    //public override Object CreateObjectToScene(Object _object, Vector3 _position, Quaternion _rotation)
    //{
    //    return UnityEngine.Object.Instantiate(_object, _position, _rotation) as GameObject;
    //}
}
