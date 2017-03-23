using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "ScriptableObject/StageLayer")]
public class StageLayer : ScriptableObject {

    [SerializeField]
    int layerNumber = 0;

    [SerializeField]
    string mission =  "";

    [SerializeField]
    MosterPicker[] mosterPicker;

    Moster[] myMosters;
    GameObject mostersGameObject;

    public void SetMosters(Moster[] _mosters) {
        myMosters = _mosters;
        foreach (Moster moster in _mosters) {
            //moster
        }
    }


    //life cycle
    public void Awake() {

    }
}

[System.Serializable]
public class MosterPicker {
    [SerializeField]
    string name;
    [SerializeField]
    MosterType type;
    [SerializeField]
    FigureValue value;
}

enum MosterType {
    Tofu
}
