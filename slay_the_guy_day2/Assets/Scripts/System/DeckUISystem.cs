using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckUISystem
{
    private List<DeckUIComponent> deckUIComponentList = new List<DeckUIComponent>();
    private List<DeckComponent> deckComponentList = new List<DeckComponent>();

    public DeckUISystem(GameEvent gameEvent)
    {
        gameEvent.AddComponentList += AddComponentList;
        gameEvent.RemoveComponentList += RemoveComponentList;
    }

    public void Update()
    {
        for (int i = 0; i < deckUIComponentList.Count; i++)
        {
            DeckUIComponent deckUIComponent = deckUIComponentList[i];
            DeckComponent deckComponent = deckComponentList[i];
            if (!deckUIComponent.gameObject.activeSelf) continue;

            deckUIComponent.DeckCountText.text = deckComponent.CardDataList.Count.ToString();
        }
    }

    private void AddComponentList(GameObject gameObject)
    {
        DeckUIComponent deckUIComponent = gameObject.GetComponent<DeckUIComponent>();
        DeckComponent deckComponent = gameObject.GetComponent<DeckComponent>();

        if (deckUIComponent == null || deckComponent == null) return;

        deckUIComponentList.Add(deckUIComponent);
        deckComponentList.Add(deckComponent);
    }

    private void RemoveComponentList(GameObject gameObject)
    {
        DeckUIComponent deckUIComponent = gameObject.GetComponent<DeckUIComponent>();
        DeckComponent deckComponent = gameObject.GetComponent<DeckComponent>();

        if (deckUIComponent == null || deckComponent == null) return;

        deckUIComponentList.Remove(deckUIComponent);
        deckComponentList.Remove(deckComponent);
    }
}
