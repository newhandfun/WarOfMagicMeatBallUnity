﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class JoystickController : ScrollRect{

	protected float radius;

	protected override void Start ()
	{
		radius = GetComponent<RectTransform>().sizeDelta.x* 0.35f;
		base.Start ();
	}

	public override void OnDrag (UnityEngine.EventSystems.PointerEventData eventData)
	{
		base.OnDrag (eventData);

		Vector2 contentPostion = base.content.anchoredPosition;

		contentPostion = Vector2.ClampMagnitude (contentPostion,radius);

		base.content.anchoredPosition = contentPostion;
	}
		
	public Vector3 GetRelativePosition(){
		return this.content.localPosition.normalized;
	}
}