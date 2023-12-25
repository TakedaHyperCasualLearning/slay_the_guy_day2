using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckSystem
{
    private List<DeckComponent> deckCardList = new List<DeckComponent>();

    public DeckSystem(GameEvent gameEvent)
    {
        gameEvent.AddComponentList += AddComponentList;
        gameEvent.RemoveComponentList += RemoveComponentList;
    }

    private void Initialize(DeckComponent deckComponent)
    {
        for (int i = 0; i < 10; i++)
        {
            deckComponent.CardDataList.Add(new CardBaseComponent());
            deckComponent.CardDataList[i].Cost = Random.Range(0, 3);
        }
    }

    public void AddComponentList(GameObject gameObject)
    {
        DeckComponent deckComponent = gameObject.GetComponent<DeckComponent>();
        if (deckComponent == null) return;

        deckCardList.Add(deckComponent);

        Initialize(deckComponent);
    }

    public void RemoveComponentList(GameObject gameObject)
    {
        DeckComponent deckComponent = gameObject.GetComponent<DeckComponent>();
        if (deckComponent == null) return;

        deckCardList.Remove(deckComponent);
    }

}
