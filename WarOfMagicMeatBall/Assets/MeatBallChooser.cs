using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MeatBallChooser : MonoBehaviour {

    public GameObject selectedColor;
    private RectTransform selectColorTran;

    public void SelectedColorUI(RectTransform _trans) {
        Debug.Log("!");
        if (selectColorTran == null) selectColorTran = selectedColor.GetComponent<RectTransform>();
        selectColorTran = _trans;
    }

}
