using UnityEngine;
using UnityEngine.EventSystems;

public class UIDragHandler : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    private RectTransform dragRectTransform;
    private Canvas canvas;
    [HideInInspector] public bool isDragging = false;
    private Transform originalParent;

    private void Start()
    {
        dragRectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
        originalParent = FindObjectOfType<CardsParent>().transform;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (!RectTransformUtility.RectangleContainsScreenPoint(dragRectTransform, eventData.position, canvas.worldCamera))
        {
            return;
        }
        isDragging = true;

        ResetCardPosition(transform);
        //dragRectTransform.SetAsLastSibling();

    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!RectTransformUtility.RectangleContainsScreenPoint(dragRectTransform, eventData.position, canvas.worldCamera))
        {
            return;
        }

        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, eventData.position, canvas.worldCamera, out Vector2 localPos);

        dragRectTransform.anchoredPosition = localPos;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        isDragging = false;
    }

    public void ResetCardPosition(Transform card)
    {
        card.SetParent(originalParent);
        //card.position = originalPosition;
    }
}
