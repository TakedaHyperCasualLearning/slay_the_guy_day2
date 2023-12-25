using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.VisualScripting;
using UnityEngine;

public enum TurnState
{
    None,
    Start,
    Draw,
    Play,
    End,
}

public class TurnSystem
{
    GameObject playerObject;
    GameObject enemyObject;

    private List<TurnComponent> turnComponentList = new List<TurnComponent>();

    public TurnSystem(GameEvent gameEvent, GameObject player, GameObject enemy)
    {
        playerObject = player;
        enemyObject = enemy;

        gameEvent.AddComponentList += AddComponentList;
        gameEvent.RemoveComponentList += RemoveComponentList;
        gameEvent.TurnEnd += TurnEnd;
    }

    private void Initialize(TurnComponent turnComponent)
    {
        if (turnComponent.gameObject == playerObject)
        {
            turnComponent.TurnStatus = TurnState.Play;
            turnComponent.IsMyTurn = true;
        }
        else
        {
            turnComponent.TurnStatus = TurnState.None;
            turnComponent.IsMyTurn = false;
        }
    }

    public void OnUpdate()
    {
        // for (int i = 0; i < turnComponentList.Count; i++)
        // {
        //     TurnComponent turnComponent = turnComponentList[i];
        //     if (!turnComponent.gameObject.activeSelf) continue;

        // }
    }

    private void TurnEnd(GameObject gameObject)
    {
        for (int i = 0; i < turnComponentList.Count; i++)
        {
            TurnComponent turnComponent = turnComponentList[i];
            if (!turnComponent.gameObject.activeSelf) continue;

            if (turnComponent.gameObject != gameObject)
            {
                turnComponent.TurnStatus = TurnState.Start;
                turnComponent.IsMyTurn = true;
                CharacterBaseComponent characterBaseComponent = turnComponent.gameObject.GetComponent<CharacterBaseComponent>();
                characterBaseComponent.Mana = characterBaseComponent.ManaMax;
                continue;
            }

            turnComponent.TurnStatus = TurnState.None;
            turnComponent.IsMyTurn = false;
        }
    }


    private void AddComponentList(GameObject gameObject)
    {
        TurnComponent turnComponent = gameObject.GetComponent<TurnComponent>();

        if (turnComponent == null) return;

        turnComponentList.Add(turnComponent);

        Initialize(turnComponent);
    }

    private void RemoveComponentList(GameObject gameObject)
    {
        TurnComponent turnComponent = gameObject.GetComponent<TurnComponent>();

        if (turnComponent == null) return;

        turnComponentList.Remove(turnComponent);
    }
}
