
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSelectSystem
{
    private GameObject playerObject;
    private GameObject enemyObject;
    private List<CardSelectComponent> cardSelectComponentList = new List<CardSelectComponent>();
    private List<CardBaseComponent> cardBaseComponentList = new List<CardBaseComponent>();

    public CardSelectSystem(GameEvent gameEvent, GameObject player, GameObject enemyObject)
    {
        this.playerObject = player;
        this.enemyObject = enemyObject;
        gameEvent.AddComponentList += AddComponentList;
        gameEvent.RemoveComponentList += RemoveComponentList;
    }

    private void Initialize(CardSelectComponent cardSelectComponent)
    {
        cardSelectComponent.BasePosition = cardSelectComponent.transform.position;
        cardSelectComponent.BaseRotation = cardSelectComponent.transform.rotation;
        cardSelectComponent.Size = cardSelectComponent.gameObject.GetComponent<RectTransform>().sizeDelta * cardSelectComponent.gameObject.transform.localScale;
    }

    public void OnUpdate()
    {
        if (!playerObject.GetComponent<TurnComponent>().IsMyTurn) return;

        List<int> selectIndexList = new List<int>();

        for (int i = 0; i < cardSelectComponentList.Count; i++)
        {
            CardSelectComponent cardSelectComponent = cardSelectComponentList[i];
            CardBaseComponent cardBaseComponent = cardBaseComponentList[i];
            if (!cardSelectComponent.gameObject.activeSelf) continue;

            if (!SelectCard(cardSelectComponent))
            {
                cardSelectComponent.transform.position = cardSelectComponent.BasePosition;
                cardSelectComponent.transform.rotation = cardSelectComponent.BaseRotation;
                continue;
            }
            cardSelectComponent.transform.position = cardSelectComponent.BasePosition + cardSelectComponent.PositionOffset;

            selectIndexList.Add(i);
            if (selectIndexList.Count >= 2)
            {
                for (int j = 0; j < selectIndexList.Count - 1; j++)
                {
                    cardSelectComponentList[selectIndexList[j]].transform.position = cardSelectComponentList[selectIndexList[j]].BasePosition;
                    cardSelectComponentList[selectIndexList[j]].transform.rotation = cardSelectComponentList[selectIndexList[j]].BaseRotation;
                }
            }

            if (!Input.GetMouseButton(0)) continue;

            if (i != selectIndexList[selectIndexList.Count - 1]) continue;

            CharacterBaseComponent characterBaseComponent = playerObject.GetComponent<CharacterBaseComponent>();
            if (characterBaseComponent.Mana < cardBaseComponent.Cost) continue;
            enemyObject.GetComponent<DamageComponent>().Damage += 1;
            playerObject.GetComponent<CharacterBaseComponent>().Mana -= cardBaseComponent.Cost;
            // cardBaseComponent.gameObject.SetActive(false);
            Vector3 tempPos = Input.mousePosition - new Vector3(Screen.width / 2, Screen.height / 2, 0);
            tempPos.z = 0;
            Debug.Log(tempPos);
            Debug.Log(cardBaseComponent.GetComponent<RectTransform>().anchoredPosition);
            cardBaseComponent.GetComponent<RectTransform>().anchoredPosition = tempPos;
            // cardSelectComponent.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -10));
            // cardSelectComponent.transform.position = new Vector3(cardSelectComponent.transform.position.x, cardSelectComponent.transform.position.y, -10);
            // Debug.Log(cardSelectComponent.transform.position);
        }
    }

    private bool SelectCard(CardSelectComponent cardSelectComponent)
    {
        Vector2 position = Camera.main.WorldToScreenPoint(cardSelectComponent.gameObject.transform.position) - new Vector3(Screen.width / 2, Screen.height / 2, 0);
        Vector2 size = cardSelectComponent.Size / 2;
        float rad = cardSelectComponent.transform.rotation.z * Mathf.Deg2Rad;
        Vector2 vertex_left_up = new Vector2(
            (-size.x) * Mathf.Cos(rad) + (size.y * -Mathf.Sin(rad)),
            (-size.x) * Mathf.Sin(rad) + (size.y * Mathf.Cos(rad)));
        Vector2 vertex_right_up = new Vector2(
            size.x * Mathf.Cos(rad) + (size.y * -Mathf.Sin(rad)),
            size.x * Mathf.Sin(rad) + (size.y * Mathf.Cos(rad)));
        Vector2 vertex_left_down = new Vector2(
            (-size.x) * Mathf.Cos(rad) + ((-size.y) * -Mathf.Sin(rad)),
            (-size.x) * Mathf.Sin(rad) + ((-size.y) * Mathf.Cos(rad)));
        Vector2 vertex_right_down = new Vector2(
            size.x * Mathf.Cos(rad) + ((-size.y) * -Mathf.Sin(rad)),
            size.x * Mathf.Sin(rad) + ((-size.y) * Mathf.Cos(rad)));

        vertex_left_up += position;
        vertex_right_up += position;
        vertex_left_down += position;
        vertex_right_down += position;

        Vector2 left_down_to_left_up = vertex_left_up - vertex_left_down;
        Vector2 left_up_to_right_up = vertex_right_up - vertex_left_up;
        Vector2 right_up_to_right_down = vertex_right_down - vertex_right_up;
        Vector2 right_down_to_left_down = vertex_left_down - vertex_right_down;

        Vector2 mousePosition = Input.mousePosition - new Vector3(Screen.width / 2, Screen.height / 2, 0);
        Vector2 left_down_to_mouse = mousePosition - vertex_left_down;
        Vector2 left_up_to_mouse = mousePosition - vertex_left_up;
        Vector2 right_up_to_mouse = mousePosition - vertex_right_up;
        Vector2 right_down_to_mouse = mousePosition - vertex_right_down;

        float crossCheck = left_down_to_left_up.x * left_down_to_mouse.y - left_down_to_mouse.x * left_down_to_left_up.y;
        if (crossCheck > 0) return false;
        crossCheck = left_up_to_right_up.x * left_up_to_mouse.y - left_up_to_mouse.x * left_up_to_right_up.y;
        if (crossCheck > 0) return false;
        crossCheck = right_up_to_right_down.x * right_up_to_mouse.y - right_up_to_mouse.x * right_up_to_right_down.y;
        if (crossCheck > 0) return false;
        crossCheck = right_down_to_left_down.x * right_down_to_mouse.y - right_down_to_mouse.x * right_down_to_left_down.y;
        if (crossCheck > 0) return false;

        return true;
    }

    public void AddComponentList(GameObject gameObject)
    {
        CardSelectComponent cardSelectComponent = gameObject.GetComponent<CardSelectComponent>();
        CardBaseComponent cardBaseComponent = gameObject.GetComponent<CardBaseComponent>();

        if (cardSelectComponent == null || cardBaseComponent == null) return;

        cardSelectComponentList.Add(cardSelectComponent);
        cardBaseComponentList.Add(cardBaseComponent);

        Initialize(cardSelectComponent);
    }

    public void RemoveComponentList(GameObject gameObject)
    {
        CardSelectComponent cardSelectComponent = gameObject.GetComponent<CardSelectComponent>();
        CardBaseComponent cardBaseComponent = gameObject.GetComponent<CardBaseComponent>();

        if (cardSelectComponent == null || cardBaseComponent == null) return;

        cardSelectComponentList.Remove(cardSelectComponent);
        cardBaseComponentList.Remove(cardBaseComponent);
    }
}
