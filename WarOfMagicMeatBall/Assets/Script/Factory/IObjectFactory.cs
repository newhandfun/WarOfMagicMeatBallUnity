using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 抽象類別
/// 用以實現brige橋接模式
/// 底下有Resrouce及Assetbundle等等的方式產生類別
/// </summary>
public abstract class IObjectFactory {

    public abstract Object LoadObject(string _name);

}
