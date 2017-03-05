using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotonFactory : IObjectFactory
{
    public override GameObject Instantiate(string _name, Vector3 _position, Quaternion _rotation)
    {
        return PhotonNetwork.Instantiate(_name,_position,_rotation,0) as GameObject;
    }
}
