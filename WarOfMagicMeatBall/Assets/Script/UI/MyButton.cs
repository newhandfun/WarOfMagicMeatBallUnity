using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MyButton : Button {

    public delegate void ButtonDelegate();

    public ButtonDelegate onButtonDownDele;
    public ButtonDelegate onButtonUpDele;

    public override void OnPointerDown(PointerEventData eventData)
    {
        base.OnPointerDown(eventData);
        if (onButtonDownDele != null) onButtonDownDele();
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        base.OnPointerUp(eventData);
        if (onButtonUpDele != null) onButtonUpDele();
    }

}
