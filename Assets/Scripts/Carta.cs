using UnityEngine;

public enum Posicion
{
    Portero,
    Defensa,
    Medio,
    Delantero
}

[CreateAssetMenu(fileName = "NuevaCarta", menuName = "Cartas/Carta")]
public class Carta : ScriptableObject
{
    public string nombre;

    public Posicion posicion;

    [Range(40, 99)]
    public int stats;

    public int precio;
}
