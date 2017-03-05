using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MeatBallSuitFactory : IInstantiateFactory
{
    public static MeatBallSuitFactory instance = new MeatBallSuitFactory();

    Dictionary<string, MeatBallSuit> MBSuitSceneDictionary = new Dictionary<string, MeatBallSuit>();
    Dictionary<string, MeatBallSuit> MBSuitDictionary = new Dictionary<string, MeatBallSuit>();

    GameObject MeatBallSuitManager = null;

    public enum MeatBallSuitEnum
    {
        Orgin
        , Warrior
        , BlackSmith
        , Archer
        //,Farmer
        //,SpearFighter
        //,OldSworder
    }
    string[] partsName = {
        "RWeapon",
        "LWeapon",
        "LGlove",
        "RGlove",
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
            var loadObject = "Prefab/Suit/" + name + "/" + name;
            var partsObject = new GameObject[partsName.Length];
            var suitMB = GetLocalFactory().LoadObject(loadObject) as GameObject;
            var icon = GetLocalFactory().LoadObject(loadObject + "_icon") as Image;
            if (suitMB != null)
            {
                for (int i = 0; i < partsName.Length; i++)
                {
                    var trans = suitMB.transform.FindChild(partsName[i]);
                    if (trans != null)
                        partsObject[i] = trans.gameObject;
                }
                var MB = new MeatBallSuit(name, partsObject, icon,RecycleSuit);
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

        MeatBallSuit newSuit = null;

        if (MBSuitSceneDictionary.ContainsKey(_name))
            return MBSuitSceneDictionary[_name];
        else
        {
            newSuit = MBSuitDictionary[_name].CopySuit();
            for (int i=0; i< newSuit.GetPartsObject().Length;i++) {
                if(newSuit.GetPartsObject()[i]!=null)
                    newSuit.GetPartsObject()[i] = GetLocalFactory().InstantiateLocal(newSuit.GetPartsObject()[i], Vector3.zero,new Quaternion());
            }
            MBSuitSceneDictionary.Add(newSuit.suitName,newSuit);
            return newSuit;
        }
    }

    public void RecycleSuit(GameObject[] _objects) {
        if (MeatBallSuitManager == null)
        {
            MeatBallSuitManager = GetLocalFactory().InstantiateLocal(new GameObject(), Vector3.zero,Quaternion.Euler(Vector3.zero));
            MeatBallSuitManager.name = "MeatBallSuitManager";
            GameObject.DontDestroyOnLoad(MeatBallSuitManager);
        }
        foreach (GameObject go in _objects) {
            if (go != null)
                go.transform.SetParent(MeatBallSuitManager.transform);
        }
        
    }

    public override GameObject CreateLocalObjectToScene(string _name)
    {
        return CreateLocalObjectToScene(_name,Vector3.zero,Quaternion.Euler(Vector3.zero));
    }

    public override GameObject CreateLocalObjectToScene(string _name, Vector3 _position)
    {
        return CreateLocalObjectToScene(_name, Vector3.zero, Quaternion.Euler(Vector3.zero));
    }

    public override GameObject CreateLocalObjectToScene(string _name, Vector3 _position, Quaternion _rotation)
    {
        return CreateLocalObjectToScene(_name, _position, _rotation);
    }
}
