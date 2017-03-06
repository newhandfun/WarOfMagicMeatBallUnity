using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 抽象類別
/// 用以實現brige橋接模式
/// 底下有Resrouce及Assetbundle等等的方式產生類別
/// </summary>
public abstract class IObjectFactory {

    public abstract GameObject Instantiate(string _name,Vector3 _position,Quaternion _rotation);

    public virtual GameObject Instantiate(string _name, Vector3 _position) {
        return Instantiate(_name,_position,Quaternion.Euler(Vector3.zero));
    }

    public virtual GameObject Instantiate(string _name) {
        return Instantiate(_name,Vector3.zero);
    }

    public virtual Object LoadObject(string _name) {
        return Resources.Load(_name);
    }

    public GameObject InstantiateLocal(GameObject _object,Vector3 _position,Quaternion _rotation) {
        return GameObject.Instantiate(_object, _position, _rotation);
    }

    public GameObject InstantiateLocal(GameObject _object,Vector3 _position) {
        return InstantiateLocal(_object,_position,Quaternion.Euler(Vector3.zero));
    }

    public GameObject InstantiateLocal(GameObject _object) {
        return InstantiateLocal(_object,Vector3.zero);
    }
}
