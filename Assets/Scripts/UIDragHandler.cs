using UnityEngine;
using UnityEngine.EventSystems;

public class UIDragHandler : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    private RectTransform dragRectTransform;
    private Canvas canvas;
    [HideInInspector] public bool isDragging = false;


    private void Start()
    {
        dragRectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (!RectTransformUtility.RectangleContainsScreenPoint(dragRectTransform, eventData.position, canvas.worldCamera))
        {
            return;
        }
        isDragging = true;

        dragRectTransform.SetAsLastSibling();
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!RectTransformUtility.RectangleContainsScreenPoint(dragRectTransform, eventData.position, canvas.worldCamera))
        {
            return;
        }

        // Get the position of the mouse cursor in canvas space
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, eventData.position, canvas.worldCamera, out Vector2 localPos);

        // Set the anchored position of the RectTransform to the mouse position
        dragRectTransform.anchoredPosition = localPos;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        isDragging = false;
    }
}
