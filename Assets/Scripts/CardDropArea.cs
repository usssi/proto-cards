using UnityEngine;
using UnityEngine.EventSystems;

public class CardDropArea : MonoBehaviour, IDropHandler
{
    public Posicion desiredPosicion;

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            MostrarCarta mostrarCarta = eventData.pointerDrag.GetComponent<MostrarCarta>();
            if (mostrarCarta != null && mostrarCarta.carta.posicion == desiredPosicion && transform.childCount == 0)
            {
                eventData.pointerDrag.transform.SetParent(transform);
                eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
            }
        }
    }
}
