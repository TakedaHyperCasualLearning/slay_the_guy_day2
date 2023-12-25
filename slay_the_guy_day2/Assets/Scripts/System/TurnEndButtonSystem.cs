using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnEndButtonSystem
{
    private GameEvent gameEvent;
    private GameObject playerObject;
    private List<TurnEndButtonComponent> turnEndButtonComponentList = new List<TurnEndButtonComponent>();

    public TurnEndButtonSystem(GameEvent gameEvent, GameObject playerObject)
    {
        this.gameEvent = gameEvent;
        this.playerObject = playerObject;

        gameEvent.AddComponentList += AddComponentList;
        gameEvent.RemoveComponentList += RemoveComponentList;
    }

    private void Initialize(TurnEndButtonComponent turnEndButtonComponent)
    {
        turnEndButtonComponent.TurnEndButton.onClick.AddListener(() => TurnEndAction(turnEndButtonComponent));
    }

    public void TurnEndAction(TurnEndButtonComponent turnEndButtonComponent)
    {
        if (!turnEndButtonComponent.gameObject.activeSelf) return;

        gameEvent.TurnEnd(playerObject);
    }

    private void AddComponentList(GameObject gameObject)
    {
        TurnEndButtonComponent turnEndButtonComponent = gameObject.GetComponent<TurnEndButtonComponent>();
        if (turnEndButtonComponent == null) return;

        turnEndButtonComponentList.Add(turnEndButtonComponent);

        Initialize(turnEndButtonComponent);
    }

    private void RemoveComponentList(GameObject gameObject)
    {
        TurnEndButtonComponent turnEndButtonComponent = gameObject.GetComponent<TurnEndButtonComponent>();
        if (turnEndButtonComponent == null) return;

        turnEndButtonComponentList.Remove(turnEndButtonComponent);
    }

}
