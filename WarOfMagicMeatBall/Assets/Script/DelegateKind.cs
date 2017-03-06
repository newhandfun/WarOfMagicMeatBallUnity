using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelegateKind {
    public delegate void VoidDelegate();
    public delegate void StringVoidDelegate(string _value);
    public delegate void IntVoidDelegate(int _value);
    public delegate void FloatVoidDelegate(float _value);
    public delegate void GameObjectsVoidDelegate(GameObject[] _gos);

    //Figure
    public delegate void HittedDelegate(int _hp, bool _isBroken);
}