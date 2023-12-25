using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawSystem
{
    private List<DeckComponent> deckComponentList = new List<DeckComponent>();

    public DrawSystem(GameEvent gameEvent)
    {
        gameEvent.AddComponentList += AddComponentList;
        gameEvent.RemoveComponentList += RemoveComponentList;
        gameEvent.DrawCard += DrawCard;
    }

    private List<CardBaseComponent> DrawCard()
    {
        List<CardBaseComponent> tempCardBaseComponentList = new List<CardBaseComponent>();
        for (int i = 0; i < deckComponentList.Count; i++)
        {
            DeckComponent deckComponent = deckComponentList[i];
            if (deckComponent.CardDataList.Count <= 0)
            {
                for (int j = 0; j < deckComponent.AfterCardDataList.Count; j++)
                {
                    CardBaseComponent cardBaseComponent = deckComponent.AfterCardDataList[j];
                    deckComponent.CardDataList.Add(cardBaseComponent);
                    deckComponent.AfterCardDataList.RemoveAt(j);
                }
            }

            for (int j = 0; j < deckComponent.DrawCount; j++)
            {
                CardBaseComponent cardBaseComponent = deckComponent.CardDataList[0];
                tempCardBaseComponentList.Add(cardBaseComponent);
                deckComponent.AfterCardDataList.Add(cardBaseComponent);
                deckComponent.CardDataList.RemoveAt(0);
            }
        }
        return tempCardBaseComponentList;
    }

    private void Shuffle()
    {

    }

    public void AddComponentList(GameObject gameObject)
    {
        DeckComponent deckComponent = gameObject.GetComponent<DeckComponent>();
        if (deckComponent == null) return;

        deckComponentList.Add(deckComponent);
    }

    public void RemoveComponentList(GameObject gameObject)
    {
        DeckComponent deckComponent = gameObject.GetComponent<DeckComponent>();
        if (deckComponent == null) return;

        deckComponentList.Remove(deckComponent);
    }
}
