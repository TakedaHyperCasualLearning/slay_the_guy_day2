using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitPointUISystem
{
    private List<CharacterBaseComponent> characterBaseComponentList = new List<CharacterBaseComponent>();
    private List<HitPointUIComponent> hitPointUIComponentList = new List<HitPointUIComponent>();

    public HitPointUISystem(GameEvent gameEvent)
    {
        gameEvent.AddComponentList += AddComponentList;
        gameEvent.RemoveComponentList += RemoveComponentList;
    }

    private void Initialize(CharacterBaseComponent characterBaseComponent, HitPointUIComponent hitPointUIComponent)
    {
        characterBaseComponent.HitPointMax = characterBaseComponent.HitPoint;
    }

    public void OnUpdate()
    {
        for (int i = 0; i < hitPointUIComponentList.Count; i++)
        {
            HitPointUIComponent hitPointUIComponent = hitPointUIComponentList[i];
            CharacterBaseComponent characterBaseComponent = characterBaseComponentList[i];
            if (!hitPointUIComponent.gameObject.activeSelf) continue;

            hitPointUIComponent.HitPointUI.text = characterBaseComponent.HitPoint.ToString() + "/" + characterBaseComponent.HitPointMax.ToString();
        }
    }

    private void AddComponentList(GameObject gameObject)
    {
        CharacterBaseComponent characterBaseComponent = gameObject.GetComponent<CharacterBaseComponent>();
        HitPointUIComponent hitPointUIComponent = gameObject.GetComponent<HitPointUIComponent>();

        if (characterBaseComponent == null || hitPointUIComponent == null) return;

        characterBaseComponentList.Add(characterBaseComponent);
        hitPointUIComponentList.Add(hitPointUIComponent);

        Initialize(characterBaseComponent, hitPointUIComponent);
    }

    private void RemoveComponentList(GameObject gameObject)
    {
        CharacterBaseComponent characterBaseComponent = gameObject.GetComponent<CharacterBaseComponent>();
        HitPointUIComponent hitPointUIComponent = gameObject.GetComponent<HitPointUIComponent>();

        if (characterBaseComponent == null || hitPointUIComponent == null) return;

        characterBaseComponentList.Remove(characterBaseComponent);
        hitPointUIComponentList.Remove(hitPointUIComponent);
    }
}
