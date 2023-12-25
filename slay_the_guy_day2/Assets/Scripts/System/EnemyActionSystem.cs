using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyActionSystem
{
    private GameEvent gameEvent;
    private GameObject playerObject;
    private List<EnemyActionComponent> enemyActionComponentList = new List<EnemyActionComponent>();
    private List<TurnComponent> turnComponentList = new List<TurnComponent>();
    private List<CharacterBaseComponent> characterBaseComponentList = new List<CharacterBaseComponent>();
    private List<DamageComponent> damageComponentList = new List<DamageComponent>();

    public EnemyActionSystem(GameEvent gameEvent, GameObject player)
    {
        this.gameEvent = gameEvent;
        playerObject = player;
        gameEvent.AddComponentList += AddComponentList;
        gameEvent.RemoveComponentList += RemoveComponentList;
    }

    public void OnUpdate()
    {
        for (int i = 0; i < enemyActionComponentList.Count; i++)
        {
            EnemyActionComponent enemyActionComponent = enemyActionComponentList[i];
            CharacterBaseComponent characterBaseComponent = characterBaseComponentList[i];
            TurnComponent turnComponent = turnComponentList[i];
            DamageComponent damageComponent = damageComponentList[i];
            if (!enemyActionComponent.gameObject.activeSelf) continue;

            if (turnComponent.IsMyTurn && turnComponent.TurnStatus == TurnState.Play || turnComponent.TurnStatus == TurnState.Start)
            {
                Debug.Log("Enemy Turn Action");
                int random = Random.Range(0, 2);
                if (random == 0)
                {
                    playerObject.GetComponent<DamageComponent>().Damage = characterBaseComponent.AttackPoint;
                    Debug.Log("Enemy Attack");
                }
                else
                {
                    damageComponent.Defense += enemyActionComponent.Defense;
                    Debug.Log("Enemy Defense");
                }

                turnComponent.TurnStatus = TurnState.End;
                Debug.Log("Enemy Turn End");
                gameEvent.TurnEnd?.Invoke(enemyActionComponent.gameObject);
            }
        }
    }

    private void AddComponentList(GameObject gameObject)
    {
        EnemyActionComponent enemyActionComponent = gameObject.GetComponent<EnemyActionComponent>();
        TurnComponent turnComponent = gameObject.GetComponent<TurnComponent>();
        CharacterBaseComponent characterBaseComponent = gameObject.GetComponent<CharacterBaseComponent>();
        DamageComponent damageComponent = gameObject.GetComponent<DamageComponent>();

        if (enemyActionComponent == null || turnComponent == null || characterBaseComponent == null || damageComponent == null) return;

        enemyActionComponentList.Add(enemyActionComponent);
        turnComponentList.Add(turnComponent);
        characterBaseComponentList.Add(characterBaseComponent);
        damageComponentList.Add(damageComponent);
    }

    private void RemoveComponentList(GameObject gameObject)
    {
        EnemyActionComponent enemyActionComponent = gameObject.GetComponent<EnemyActionComponent>();
        TurnComponent turnComponent = gameObject.GetComponent<TurnComponent>();
        CharacterBaseComponent characterBaseComponent = gameObject.GetComponent<CharacterBaseComponent>();
        DamageComponent damageComponent = gameObject.GetComponent<DamageComponent>();

        if (enemyActionComponent == null || turnComponent == null || characterBaseComponent == null || damageComponent == null) return;

        enemyActionComponentList.Remove(enemyActionComponent);
        turnComponentList.Remove(turnComponent);
        characterBaseComponentList.Remove(characterBaseComponent);
        damageComponentList.Remove(damageComponent);
    }
}
