using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class JoystickController : ScrollRect{
    /// <summary>
    /// Max Radius
    /// </summary>
	protected float radius;
    /// <summary>
    /// 1/radius
    /// </summary>
    protected float radius1;

    /// <summary>
    /// Delegate happened when player Drag
    /// </summary>
    public delegate void OnDragDele(float _x, float _y);
    public OnDragDele myOnDragDele;
    public OnDragDele myOnExitDele;

	protected override void Start ()
	{
		base.Start ();
	}

    public void OnStart() {
        var myRect = GetComponent<RectTransform>();
        myRect.sizeDelta = new Vector2(myRect.rect.height, 0);
        radius = myRect.rect.height * 0.4f;
        radius1 = 1 / radius;
    }

	public override void OnDrag (UnityEngine.EventSystems.PointerEventData eventData)
	{
		base.OnDrag (eventData);

        content.position = Input.mousePosition;

        content.anchoredPosition = Vector3.ClampMagnitude(base.content.anchoredPosition, this.radius);

        if (myOnDragDele != null) {
            myOnDragDele(base.content.anchoredPosition.x*radius1, base.content.anchoredPosition.y*radius1);
        }
	}

    public override void OnEndDrag(PointerEventData eventData)
    {
        base.OnEndDrag(eventData);
        if (myOnExitDele != null) myOnExitDele(0,0);
    }

    public Vector3 GetRelativePosition(){
		return this.content.localPosition.normalized;
	}
}
