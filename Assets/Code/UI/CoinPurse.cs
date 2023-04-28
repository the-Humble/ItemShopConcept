using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinPurse : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _goldDisplay;

    public void UpdateGoldDisplay(int gold)
    {
        _goldDisplay.text = gold.ToString();
    }
}
