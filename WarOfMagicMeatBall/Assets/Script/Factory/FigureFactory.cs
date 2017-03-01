using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FigureFactory : IInstantiateFactory{

    public static FigureFactory instance = new FigureFactory();

    public enum FigureLocation {
        Orgin,
        MeatBall,
        Building,
        Other
    }
    public FigureLocation figureLocation = FigureLocation.Orgin;

    //沒路徑的
    public override GameObject CreateObjectToScene(string _name)
    {
        return CreateObjectToScene(_name, Vector3.zero, Quaternion.Euler(Vector3.zero));
    }

    public override GameObject CreateObjectToScene(string _name, Vector3 _position)
    {
        return CreateObjectToScene(_name,_position,Quaternion.Euler(Vector3.zero));
    }

    public override GameObject CreateObjectToScene(string _name, Vector3 _position, Quaternion _rotation)
    {
        if (figureLocation != FigureLocation.Orgin) _name = figureLocation.ToString() + @"/" + _name;
        _name = ResrouceFactory.FigureLocation + _name;

        Debug.Log(_name);

        var nObject = UnityEngine.Object.Instantiate(GetObjectFactory().LoadObject(_name)) as GameObject;
        nObject.transform.position = _position;
        nObject.transform.rotation = _rotation;
        return nObject;
    }


    //各資料夾底下的函式
    public GameObject CreateMeatBallToScene(Vector3 _postion,Quaternion _rotation)
    {
        figureLocation = FigureLocation.MeatBall;
        var _name = "MeatBall";
        return CreateObjectToScene(_name, _postion,_rotation);
    }
    public GameObject CreateMeatBallToScene(string _name ,Vector3 _postion, Quaternion _rotation)
    {
        figureLocation = FigureLocation.MeatBall;
        return CreateObjectToScene(_name, _postion, _rotation);
    }
}
