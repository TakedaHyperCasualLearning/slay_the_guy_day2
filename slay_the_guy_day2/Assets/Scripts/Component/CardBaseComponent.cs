using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CardBaseComponent : MonoBehaviour
{
    [SerializeField] private int cost;
    [SerializeField] private TextMeshProUGUI costText;

    public int Cost { get => cost; set => cost = value; }
    public TextMeshProUGUI CostText { get => costText; set => costText = value; }
}
