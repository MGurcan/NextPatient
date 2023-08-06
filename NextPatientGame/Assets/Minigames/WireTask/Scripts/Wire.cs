using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Wire : MonoBehaviour, /*IPointerDownHandler, */ IDragHandler, IBeginDragHandler, IEndDragHandler
{
    private Image image;
    public Color CustomColor;
    private LineRenderer lineRenderer;
    private Canvas canvas;

    private bool isDragStarted = false;

    public bool isLeftWire;

    private WireTask wireTask;

    public bool IsSuccess = false;
    private void Awake()
    {
        image = GetComponent<Image>();
        lineRenderer = GetComponent<LineRenderer>();

        canvas = GetComponentInParent<Canvas>();
        wireTask = GetComponentInParent<WireTask>();
    }

    private void Update()
    {
        if (isDragStarted) 
        {
            Vector2 movePos;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                canvas.transform as RectTransform,
                Input.mousePosition,
                canvas.worldCamera,
                out movePos
                );
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, canvas.transform.TransformPoint(movePos));
        }
        else
        {
            if (!IsSuccess)
            {
                lineRenderer.SetPosition(0, Vector3.zero);
                lineRenderer.SetPosition(1, Vector3.zero);
            }
        }

        bool isHovered = RectTransformUtility.RectangleContainsScreenPoint(transform as RectTransform, Input.mousePosition, canvas.worldCamera);

        if (isHovered)
        {
            wireTask.CurrentHoveredWire = this;
        }
    }
    public void SetColor(Color color)
    {
        CustomColor = color;
        image.color = color;
        lineRenderer.startColor = color;
        lineRenderer.endColor = color;
    }

    void IDragHandler.OnDrag(PointerEventData eventData)
    {
    }

    void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
    {
        if (!isLeftWire) return;
        if (IsSuccess) return;
        
        isDragStarted = true;
        wireTask.CurrentDraggedWire = this;
    }

    void IEndDragHandler.OnEndDrag(PointerEventData eventData)
    {
        if(wireTask.CurrentHoveredWire != null)
        {
            if(wireTask.CurrentHoveredWire.CustomColor == CustomColor && !wireTask.CurrentHoveredWire.isLeftWire)
            {
                IsSuccess = true;
                wireTask.CurrentHoveredWire.IsSuccess = true;
            }
        }
        isDragStarted = false;
        wireTask.CurrentDraggedWire = null;
    }
}
