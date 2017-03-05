using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIFactory : IInstantiateFactory
{
    public static UIFactory instance = new UIFactory();

    //從頭到尾都在場上的UI
    private  GameObject usuallyRefreshCanvas = null;
    private GameObject suddenlyRefreshCanvas = null;
    private GameObject unRefreshCanvas = null;

    public enum RefreshCanvasType {
        usuallyRefreshCanvas, suddenlyRefreshCanvas, unRefreshCanvas
    }

    public RefreshCanvasType refreshCanvas = RefreshCanvasType.usuallyRefreshCanvas;

    public  GameObject UsuallyRefreshCanvas
    {
        get
        {
            if (usuallyRefreshCanvas == null)
            {
                usuallyRefreshCanvas = GetLocalFactory().Instantiate(ResrouceFactory.UILocation + "Canvas", Vector3.zero);
                usuallyRefreshCanvas.name = "usuallyRefreshCanvas";
                GameObject.DontDestroyOnLoad(usuallyRefreshCanvas);
            }
            return usuallyRefreshCanvas;
        }
    }

    public GameObject SuddenlyRefreshCanvas
    {
        get
        {
            if (suddenlyRefreshCanvas == null)
            {
                suddenlyRefreshCanvas = GetLocalFactory().Instantiate(ResrouceFactory.UILocation + "Canvas", Vector3.zero);
                suddenlyRefreshCanvas.name = "usuallyRefreshCanvas";
                GameObject.DontDestroyOnLoad(suddenlyRefreshCanvas);
            }
            return suddenlyRefreshCanvas;
        }
    }

    public GameObject UnRefreshCanvas
    {
        get
        {
            if (unRefreshCanvas == null)
            {
                unRefreshCanvas = GetLocalFactory().Instantiate(ResrouceFactory.UILocation + "Canvas",Vector3.zero);
                unRefreshCanvas.name = "usuallyRefreshCanvas";
                GameObject.DontDestroyOnLoad(unRefreshCanvas);
            }
            return unRefreshCanvas;
        }
    }

    public override UnityEngine.GameObject CreateLocalObjectToScene(string _name)
    {
        return CreateLocalObjectToScene(_name, Vector3.zero, Quaternion.Euler(Vector3.zero));
    }

    public override GameObject CreateLocalObjectToScene(string _name, Vector3 _position)
    {
        return CreateLocalObjectToScene(_name,_position,Quaternion.Euler(Vector3.zero));
    }

    public override GameObject CreateLocalObjectToScene(string _name, Vector3 _position, Quaternion _rotation)
    {
        var UI = GetLocalFactory().Instantiate(ResrouceFactory.UILocation + _name) as GameObject;
        var UIRect = UI.GetComponent<RectTransform>();

        switch (refreshCanvas)
        {
            case RefreshCanvasType.usuallyRefreshCanvas:
                UIRect.SetParent(UsuallyRefreshCanvas.transform);
                break;
            case RefreshCanvasType.suddenlyRefreshCanvas:
                UIRect.SetParent(SuddenlyRefreshCanvas.transform);
                break;
            case RefreshCanvasType.unRefreshCanvas:
                UIRect.SetParent(UnRefreshCanvas.transform);
                break;
        }

        UIRect.sizeDelta = Vector2.zero;
        UIRect.localPosition = _position;
        UIRect.rotation = _rotation;

        return UI;
    }
}
