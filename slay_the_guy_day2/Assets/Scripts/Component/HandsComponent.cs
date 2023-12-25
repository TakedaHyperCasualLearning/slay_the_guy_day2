using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandsComponent : MonoBehaviour
{
    [SerializeField] private List<CardBaseComponent> handsCardList = new List<CardBaseComponent>();

    public List<CardBaseComponent> HandsCardList { get => handsCardList; set => handsCardList = value; }
}
