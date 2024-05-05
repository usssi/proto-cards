using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyController : MonoBehaviour
{
    public TextMeshProUGUI moneyText;
    public int money;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moneyText.text = "$: " + money.ToString();
    }
}
