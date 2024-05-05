using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class GeneradorCarta : MonoBehaviour
{
    public GameObject cartaPrefab;
    private GameObject cartaParent;
    public string packName;
    public TextMeshProUGUI textoNombre;

    [SerializeField] private List<string[]>[] rankPools;

     public int amountOfCardsToCreate = 1;
     public List<int> rankProbabilities = new List<int>();
    public float radius = 10f;

    private void Start()
    {
        // Initialize rankProbabilities list with default values if it's empty
        while (rankProbabilities.Count < 5)
        {
            rankProbabilities.Add(0);
        }

        cartaParent = FindObjectOfType<CardsParent>().gameObject;
        textoNombre.text = packName;
    }

    public void CreateCards()
    {
        LoadCardPools();
        
        float angleStep = Mathf.PI * 2f / amountOfCardsToCreate;
        float currentAngle = 0f;

        for (int i = 0; i < amountOfCardsToCreate; i++)
        {
            int selectedRank = SelectRank();
            string[] selectedCard = SelectRandomCard(selectedRank);

            // Calculate the position for the new card
            float xPos = transform.position.x + radius * Mathf.Cos(currentAngle);
            float yPos = transform.position.y + radius * Mathf.Sin(currentAngle);
            Vector3 cardPosition = new Vector3(xPos, yPos, transform.position.z);

            // Instantiate the card prefab at the calculated position
            GameObject nuevaCartaObj = Instantiate(cartaPrefab, cardPosition, Quaternion.identity, cartaParent.transform);

            // Update the current angle for the next card position
            currentAngle += angleStep;

            MostrarCarta mostrarCarta = nuevaCartaObj.GetComponent<MostrarCarta>();
            Carta newCarta = ScriptableObject.CreateInstance<Carta>();

            newCarta.nombre = selectedCard[1]; // Name
            newCarta.posicion = TranslatePosition(selectedCard[3]); // Position
            newCarta.stats = int.Parse(selectedCard[2]); // Stat
            newCarta.precio = int.Parse(selectedCard[4]); // Price

            mostrarCarta.carta = newCarta;

            // Remove the selected card from the pool
            rankPools[selectedRank].Remove(selectedCard);
        }
    }


    private void LoadCardPools()
    {
        rankPools = new List<string[]>[rankProbabilities.Count];

        for (int i = 0; i < rankProbabilities.Count; i++)
        {
            rankPools[i] = new List<string[]>();

            string filePath = Path.Combine(Application.streamingAssetsPath, "rank_" + i + ".csv");
            string[] lines = File.ReadAllLines(filePath);

            for (int j = 1; j < lines.Length; j++) // Skip header
            {
                string[] fields = lines[j].Split(',');
                rankPools[i].Add(fields);
            }
        }
    }

    private int SelectRank()
    {
        int totalProbability = 0;

        foreach (int probability in rankProbabilities)
        {
            totalProbability += probability;
        }

        int randomValue = Random.Range(0, totalProbability);
        int cumulativeProbability = 0;

        for (int i = 0; i < rankProbabilities.Count; i++)
        {
            cumulativeProbability += rankProbabilities[i];

            if (randomValue < cumulativeProbability)
            {
                return i;
            }
        }

        return rankProbabilities.Count - 1;
    }

    private string[] SelectRandomCard(int rank)
    {
        List<string[]> rankPool = rankPools[rank];
        int randomIndex = Random.Range(0, rankPool.Count);
        return rankPool[randomIndex];
    }

    private Posicion TranslatePosition(string positionName)
    {
        switch (positionName)
        {
            case "GK":
                return Posicion.Portero;
            case "LB":
            case "CB":
            case "RB":
            case "LWB":
            case "RWB":
                return Posicion.Defensa;
            case "CDM":
            case "LM":
            case "CM":
            case "RM":
            case "CAM":
                return Posicion.Medio;
            case "LW":
            case "RW":
            case "LF":
            case "CF":
            case "RF":
            case "ST":
                return Posicion.Delantero;
            default:
                Debug.LogWarning("Unknown position: " + positionName);
                return Posicion.Portero; // Default to Portero if position is unknown
        }
    }
}
