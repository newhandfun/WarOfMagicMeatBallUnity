using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 抽象類別
/// 用於實例化物件
/// </summary>
public abstract class IInstantiateFactory {
    private IObjectFactory myObjectFactory = null;

    public IObjectFactory GetObjectFactory() {
        if (myObjectFactory == null)
            myObjectFactory = new ResrouceFactory();
        return myObjectFactory;
    }

    public abstract GameObject CreateObjectToScene(string _name);
    public abstract GameObject CreateObjectToScene(string _name,Vector3 _position);
    public abstract GameObject CreateObjectToScene(string _name, Vector3 _position,Quaternion _rotation);

    public virtual void Instantiate(GameObject _object, Vector3 _position, Quaternion _rotation) {
        GameObject.Instantiate(_object,_position,_rotation);
    }
    public virtual void Instantiate(GameObject _object, Vector3 _position)
    {
        GameObject.Instantiate(_object, _position, Quaternion.Euler(Vector3.zero));
    }
}
