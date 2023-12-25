using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject enemy;
    [SerializeField] GameObject turnEndButton;
    [SerializeField] List<GameObject> cardList;
    [SerializeField] GameObject deckObject;
    [SerializeField] GameObject handsObject;
    private GameEvent gameEvent;

    private HitPointUISystem hitPointUISystem;
    private CardSelectSystem cardSelectSystem;
    private DamageSystem damageSystem;
    private TurnSystem turnSystem;
    private TurnEndButtonSystem turnEndButtonSystem;
    private EnemyActionSystem enemyActionSystem;
    private ManaUISystem manaUISystem;
    private DeckSystem deckSystem;
    private DrawSystem drawSystem;
    private HandsSystem handsSystem;
    private DeckUISystem deckUISystem;

    void Start()
    {
        gameEvent = new GameEvent();

        hitPointUISystem = new HitPointUISystem(gameEvent);
        cardSelectSystem = new CardSelectSystem(gameEvent, player, enemy);
        damageSystem = new DamageSystem(gameEvent);
        turnSystem = new TurnSystem(gameEvent, player, enemy);
        turnEndButtonSystem = new TurnEndButtonSystem(gameEvent, player);
        enemyActionSystem = new EnemyActionSystem(gameEvent, player);
        manaUISystem = new ManaUISystem(gameEvent);

        deckSystem = new DeckSystem(gameEvent);
        drawSystem = new DrawSystem(gameEvent);
        handsSystem = new HandsSystem(gameEvent, player);
        deckUISystem = new DeckUISystem(gameEvent);


        gameEvent.AddComponentList?.Invoke(player);
        gameEvent.AddComponentList?.Invoke(enemy);
        gameEvent.AddComponentList?.Invoke(turnEndButton);
        gameEvent.AddComponentList?.Invoke(deckObject);
        gameEvent.AddComponentList?.Invoke(handsObject);
        for (int i = 0; i < cardList.Count; i++)
        {
            gameEvent.AddComponentList?.Invoke(cardList[i]);
        }
    }

    void Update()
    {
        hitPointUISystem.OnUpdate();
        cardSelectSystem.OnUpdate();
        damageSystem.OnUpdate();
        turnSystem.OnUpdate();
        enemyActionSystem.OnUpdate();
        manaUISystem.OnUpdate();
        handsSystem.OnUpdate();
        deckUISystem.Update();
    }
}
