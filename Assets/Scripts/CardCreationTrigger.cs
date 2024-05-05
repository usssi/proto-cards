using UnityEngine;
using UnityEngine.EventSystems;

public class CardCreationTrigger : MonoBehaviour, IPointerUpHandler
{
    private GeneradorCarta generadorCarta;
    private UIDragHandler dragHandler;
    private bool wasDragging = false;

    private void Start()
    {
        generadorCarta = GetComponent<GeneradorCarta>();

        dragHandler = GetComponent<UIDragHandler>();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (dragHandler != null)
        {
            if (dragHandler.isDragging)
            {
                wasDragging = true;
                return; 
            }
            else
            {
                wasDragging = false;
            }
        }

        if (generadorCarta != null && !wasDragging)
        {
            generadorCarta.CreateCards();
            Destroy(gameObject);
        }
    }
}
