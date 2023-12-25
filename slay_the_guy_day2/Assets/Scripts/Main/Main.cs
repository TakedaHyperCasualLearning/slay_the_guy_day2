using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject enemy;
    [SerializeField] List<GameObject> cardList;
    private GameEvent gameEvent;

    private HitPointUISystem hitPointUISystem;
    private CardSelectSystem cardSelectSystem;
    void Start()
    {
        gameEvent = new GameEvent();

        hitPointUISystem = new HitPointUISystem(gameEvent);
        cardSelectSystem = new CardSelectSystem(gameEvent);

        gameEvent.AddComponentList?.Invoke(player);
        gameEvent.AddComponentList?.Invoke(enemy);
        for (int i = 0; i < cardList.Count; i++)
        {
            gameEvent.AddComponentList?.Invoke(cardList[i]);
        }
    }

    void Update()
    {
        hitPointUISystem.OnUpdate();
        cardSelectSystem.OnUpdate();
    }
}
