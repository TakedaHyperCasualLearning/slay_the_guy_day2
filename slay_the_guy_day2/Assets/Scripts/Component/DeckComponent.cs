using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckComponent : MonoBehaviour
{
    private List<CardBaseComponent> cardDataList = new List<CardBaseComponent>();
    private List<CardBaseComponent> afterCardDataList = new List<CardBaseComponent>();
    [SerializeField] private int drawCount;

    public List<CardBaseComponent> CardDataList { get => cardDataList; set => cardDataList = value; }
    public List<CardBaseComponent> AfterCardDataList { get => afterCardDataList; set => afterCardDataList = value; }
    public int DrawCount { get => drawCount; set => drawCount = value; }
}
