using UnityEngine;
using UnityEngine.EventSystems;

public class CardSeller : MonoBehaviour, IDropHandler
{
    public MoneyController moneyController;

    public void OnDrop(PointerEventData eventData)
    {

        if (eventData.pointerDrag != null && eventData.pointerDrag.GetComponent<MostrarCarta>() != null)
        {
            MostrarCarta mostrarCarta = eventData.pointerDrag.GetComponent<MostrarCarta>();

            int cardPrice = mostrarCarta.carta.precio;

            moneyController.money += cardPrice;

            print("Selling card");

            Destroy(eventData.pointerDrag);
        }
    }
}
