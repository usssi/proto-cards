using UnityEngine;
using TMPro;

public class MostrarCarta : MonoBehaviour
{
    public Carta carta; 
    public TextMeshProUGUI nombreText;
    public TextMeshProUGUI posicionText;
    public TextMeshProUGUI statsText;
    public TextMeshProUGUI precioText;

    void Start()
    {
        if (carta != null)
        {
            nombreText.text = carta.nombre;
            posicionText.text = carta.posicion.ToString();
            statsText.text = carta.stats.ToString();
            precioText.text = "$" + carta.precio.ToString();

            Color color = Color.white; 
            switch (carta.posicion)
            {
                case Posicion.Portero:
                    color = Color.yellow;
                    break;
                case Posicion.Defensa:
                    color = Color.cyan;
                    break;
                case Posicion.Medio:
                    color = Color.green;
                    break;
                case Posicion.Delantero:
                    color = Color.red;
                    break;
            }
            posicionText.color = color;
        }
        else
        {
            Debug.LogError("La referencia a la carta es nula.");
        }
    }
}
