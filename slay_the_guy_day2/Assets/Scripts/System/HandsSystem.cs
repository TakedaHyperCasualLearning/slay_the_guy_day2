using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HandsSystem
{
    private GameEvent gameEvent;
    private GameObject playerObject;
    private List<HandsComponent> handsComponentList = new List<HandsComponent>();

    public HandsSystem(GameEvent gameEvent, GameObject player)
    {
        this.gameEvent = gameEvent;
        this.playerObject = player;

        gameEvent.AddComponentList += AddComponentList;
        gameEvent.RemoveComponentList += RemoveComponentList;
    }

    public void OnUpdate()
    {
        TurnComponent turnComponent = playerObject.GetComponent<TurnComponent>();
        if (turnComponent.TurnStatus != TurnState.Draw && turnComponent.TurnStatus != TurnState.Start) return;

        for (int i = 0; i < handsComponentList.Count; i++)
        {
            HandsComponent handsComponent = handsComponentList[i];
            if (!handsComponent.gameObject.activeSelf) continue;

            List<CardBaseComponent> cardBaseComponentList = gameEvent.DrawCard();
            if (cardBaseComponentList.Count == 0) continue;
            for (int j = 0; j < cardBaseComponentList.Count; j++)
            {
                if (handsComponent.HandsCardList.Count <= j) break;
                CardBaseComponent cardBaseComponent = cardBaseComponentList[j];
                handsComponent.HandsCardList[j].Cost = cardBaseComponent.Cost;
                handsComponent.HandsCardList[j].CostText.text = cardBaseComponent.Cost.ToString();
                handsComponent.HandsCardList[j].gameObject.SetActive(true);
            }
            playerObject.GetComponent<TurnComponent>().TurnStatus = TurnState.Play;
            Debug.Log("Player Turn Draw");
        }
    }

    private void AddComponentList(GameObject gameObject)
    {
        HandsComponent handsComponent = gameObject.GetComponent<HandsComponent>();
        if (handsComponent == null) return;

        handsComponentList.Add(handsComponent);
    }

    private void RemoveComponentList(GameObject gameObject)
    {
        HandsComponent handsComponent = gameObject.GetComponent<HandsComponent>();
        if (handsComponent == null) return;

        handsComponentList.Remove(handsComponent);
    }
}
