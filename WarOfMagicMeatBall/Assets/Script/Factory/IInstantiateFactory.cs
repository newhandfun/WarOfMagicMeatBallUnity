using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 抽象類別
/// 用於實例化物件
/// </summary>
public abstract class IInstantiateFactory {

    private IObjectFactory myLocalFactory = null;
    private IObjectFactory myConnectionFactory = null;

    public IObjectFactory GetLocalFactory() {
        if (myLocalFactory == null)
        {
            myLocalFactory = new ResrouceFactory();
        }
        return myLocalFactory;
    }

    public IObjectFactory ConnectionFactory{
        get {
            switch (Connection.GetConnectionMethod)
            {
                case ConnectionMethod.Photon:
                    myLocalFactory = new PhotonFactory();
                    break;
                case ConnectionMethod.Unet:
                    myLocalFactory = new UnetFactory();
                    break;
                default:
                    myLocalFactory = new ResrouceFactory();
                    break;
            }
            return myConnectionFactory;
        }
    }

    public virtual GameObject CreateLocalObjectToScene(string _name, Vector3 _position, Quaternion _rotation) {
        return GetLocalFactory().Instantiate(_name,_position,_rotation) as GameObject;
    }

    public virtual GameObject CreateLocalObjectToScene(string _name) {
        return CreateLocalObjectToScene(_name,Vector3.zero,Quaternion.Euler(Vector3.zero));
    }
    public virtual GameObject CreateLocalObjectToScene(string _name,Vector3 _position)
    {
        return CreateLocalObjectToScene(_name, _position, Quaternion.Euler(Vector3.zero));
    }

    public virtual GameObject CreateConnectionObjectToScene(string _name, Vector3 _position, Quaternion _rotation)
    {
        return ConnectionFactory.Instantiate(_name, _position, _rotation) as GameObject;
    }

    public virtual GameObject CreateConnectionObjectToScene(string _name)
    {
        return CreateConnectionObjectToScene(_name, Vector3.zero, Quaternion.Euler(Vector3.zero));
    }
    public virtual GameObject CreateConnectionObjectToScene(string _name, Vector3 _position)
    {
        return CreateConnectionObjectToScene(_name, _position, Quaternion.Euler(Vector3.zero));
    }
}
