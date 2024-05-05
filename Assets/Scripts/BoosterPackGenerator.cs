using TMPro;
using UnityEngine;

public class BoosterPackGenerator : MonoBehaviour
{
    private MoneyController moneyController;
    private Transform parentTransform;

    public string packName;
    public int packCost;
    public TextMeshProUGUI precioText;
    public TextMeshProUGUI nombreText;

    public GameObject boosterPackPrefab;

    private void Start()
    {
        moneyController = FindObjectOfType<MoneyController>();
        parentTransform = FindObjectOfType<CardsParent>().gameObject.transform;
        precioText.text = "$: " + packCost.ToString();
        nombreText.text = packName;
    }

    public void GenerateBoosterPack()
    {
        if (moneyController.money >= packCost)
        {
            if (boosterPackPrefab != null)
            {
                RectTransform canvasRect = parentTransform.GetComponent<RectTransform>();
                Vector3 center = canvasRect.position;

                GameObject newBoosterPack = Instantiate(boosterPackPrefab, center, Quaternion.identity, parentTransform);

                RectTransform boosterPackRectTransform = newBoosterPack.GetComponent<RectTransform>();
                boosterPackRectTransform.anchoredPosition = Vector2.zero;

                moneyController.money -= packCost;
            }
            else
                Debug.LogWarning("No prefab assigned");
        }
        else
            Debug.LogWarning("Not enough money to purchase the booster pack! " + moneyController.money + " " + packCost);
    }

}
