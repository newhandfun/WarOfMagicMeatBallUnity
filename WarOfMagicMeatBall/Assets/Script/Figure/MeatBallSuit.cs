using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MeatBallSuit
{
    public string suitName;
    public Image icon;

    private GameObject[] partsObject;

    public DelegateKind.GameObjectsVoidDelegate takeOffDelegate;

    public GameObject[] GetPartsObject()
    {
        if (partsObject == null) Debug.Log("NULL SUIT");
        return partsObject;
    }

    public MeatBallSuit(string _name, GameObject[] _parts, Image _icon, DelegateKind.GameObjectsVoidDelegate _dele)
    {
        suitName = _name;
        partsObject = _parts;
        icon = _icon;
        takeOffDelegate = _dele;
    }

    public bool isCommonSuit(MeatBallSuit _suit)
    {
        if (_suit == null) return false;
        return this.suitName == _suit.suitName;
    }

    public MeatBallSuit CopySuit()
    {
        return new MeatBallSuit(suitName, partsObject, icon, takeOffDelegate);
    }


    public void Show()
    {
        foreach (GameObject go in partsObject)
        {
            if (go != null)
                go.SetActive(true);
        }
    }

    private void Hide()
    {
        foreach (GameObject go in partsObject)
        {
            if (go != null)
                go.SetActive(false);
        }
    }

    public void TakeOff()
    {
        if (takeOffDelegate == null)
        {
            Debug.Log("回收委派為空，請檢查程式碼!");
            return;
        }
        Hide();
        takeOffDelegate(this.GetPartsObject());

    }
}