using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MeatBallSuitFactory : IInstantiateFactory
{
    public static MeatBallSuitFactory instance = new MeatBallSuitFactory();

    Dictionary<string, GameObject[]> MBSuitSceneDictionary = new Dictionary<string, GameObject[]>();
    Dictionary<string, MeatBallSuit> MBSuitDictionary = new Dictionary<string, MeatBallSuit>();

    GameObject MeatBallSuitManager = null;

    public enum MeatBallSuitEnum
    {
        Orgin
        , Warrior
        , BlackSmith
        , Archor
        //,Farmer
        //,SpearFighter
        //,OldSworder
    }
    string[] partsName = {
        "RWeapon",
        "LWeapon",
        "LShoes",
        "RShoes",
        "Cloak",
        "Hat",
        "Cloth"
    };

    public MeatBallSuitFactory()
    {
        foreach (MeatBallSuitEnum mbe in Enum.GetValues(typeof(MeatBallSuitEnum)))
        {
            var name = mbe.ToString();
            var load = "Prefab/Suit/" + name + "/" + name;
            var partsObject = new GameObject[partsName.Length];
            var suitMB = GetObjectFactory().LoadObject(load) as GameObject;
            var icon = GetObjectFactory().LoadObject(load + "_icon") as Image;
            if (suitMB != null)
            {
                for (int i = 0; i < partsName.Length; i++)
                {
                    var trans = suitMB.transform.FindChild(partsName[i]);
                    if (trans != null)
                        partsObject[i] = trans.gameObject;
                }
                var MB = new MeatBallSuit(name, partsObject, icon);
                MBSuitDictionary.Add(name, MB);
            }
            else
                Debug.Log(name + ":沒有Prefab!檢查一下!");

        }
    }

    public bool isHavingSuit(string _name) {
        return MBSuitDictionary.ContainsKey(_name);
    }

    public MeatBallSuit GetSuitByName(string _name) {

        if (!isHavingSuit(_name)) return null;

        if (MBSuitSceneDictionary.ContainsKey(_name)) {
            if(MBSuitSceneDictionary[_name]!=null)
                return new MeatBallSuit(_name, MBSuitSceneDictionary[_name], MBSuitDictionary[_name].icon);
        }
        else {
            MBSuitSceneDictionary.Remove(_name);
        }

        var parts = new GameObject[partsName.Length];
        for (int i = 0; i < partsName.Length; i++)
        {
            if(MBSuitDictionary[_name].GetPartsObject()[i] !=null)
            parts[i] = 
                 Instantiate(MBSuitDictionary[_name].GetPartsObject()[i],Vector3.zero)
                    as GameObject;
        }

        MBSuitSceneDictionary.Add(_name,parts);

        return new MeatBallSuit(_name,MBSuitSceneDictionary[_name],MBSuitDictionary[_name].icon);
    }

    public override GameObject CreateObjectToScene(string _name)
    {
        return CreateObjectToScene(_name,Vector3.zero,Quaternion.Euler(Vector3.zero));
    }

    public override GameObject CreateObjectToScene(string _name, Vector3 _position)
    {
        return CreateObjectToScene(_name, Vector3.zero, Quaternion.Euler(Vector3.zero));
    }

    public override GameObject CreateObjectToScene(string _name, Vector3 _position, Quaternion _rotation)
    {
        return CreateObjectToScene(_name, _position, _rotation);
    }
}
