using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MeatBallChooser : MonoBehaviour {

    public void SelectedColorUI(RectTransform _trans)
    {
        if (selectColorTran == null) selectColorTran = selectedColor.GetComponent<RectTransform>();
        if (colorUIAnimate != null) StopCoroutine(colorUIAnimate);
        colorUIAnimate = StartCoroutine(SetColorUIPositionToZero(selectColorTran, _trans));
        var spriteName = _trans.gameObject.GetComponent<Image>().sprite.name;
        var colorIndex =int.Parse(spriteName.Split('_')[2]);
        if(chooseColor!=null) chooseColor(colorIndex);
    }

    public void SelectedSuitUI(RectTransform _trans)
    {
        if (selectSuitTran == null) selectSuitTran = selectSuit.GetComponent<RectTransform>();
        if (suitUIAnimate != null) StopCoroutine(suitUIAnimate);
        suitUIAnimate = StartCoroutine(SetColorUIPositionToZero(selectSuitTran, _trans));
        if (chooseSuit != null) chooseSuit(_trans.name);
    }

    #region UI
    public GameObject selectedColor;
    private RectTransform selectColorTran;

    public GameObject selectSuit;
    private RectTransform selectSuitTran;

    Coroutine colorUIAnimate;
    Coroutine suitUIAnimate;


    IEnumerator SetColorUIPositionToZero(RectTransform _trans,RectTransform _parent) {
        _trans.SetParent(_parent);
        _trans.anchorMin = Vector2.zero;
        _trans.anchorMax = new Vector2(1f, 1f);
        _trans.sizeDelta = Vector2.zero;
        for (int i=0; i< 30;i++) {
            _trans.localPosition = Vector3.Lerp(_trans.localPosition,Vector3.zero,20f*Time.deltaTime);
            _trans.anchoredPosition = Vector3.Lerp(_trans.anchoredPosition, Vector3.zero, 20f * Time.deltaTime);
            yield return new WaitForSeconds(0.05f);
        }
    }
    #endregion

    #region Value&Delegate
    public DelegateKind.IntVoidDelegate chooseColor;
    public DelegateKind.StringVoidDelegate chooseSuit;
    #endregion


}
