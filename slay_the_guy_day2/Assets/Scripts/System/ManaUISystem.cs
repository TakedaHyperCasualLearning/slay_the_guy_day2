using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaUISystem
{
    private List<ManaUIComponent> manaUIComponentList = new List<ManaUIComponent>();
    private List<CharacterBaseComponent> characterBaseComponentList = new List<CharacterBaseComponent>();

    public ManaUISystem(GameEvent gameEventSystem)
    {
        gameEventSystem.AddComponentList += AddComponentList;
        gameEventSystem.RemoveComponentList += RemoveComponentList;
    }

    private void Initialize(ManaUIComponent manaUIComponent, CharacterBaseComponent characterBaseComponent)
    {
        characterBaseComponent.ManaMax = characterBaseComponent.Mana;
        manaUIComponent.ManaText.text = characterBaseComponent.Mana.ToString() + "/" + characterBaseComponent.ManaMax.ToString();
    }

    public void OnUpdate()
    {
        for (int i = 0; i < manaUIComponentList.Count; i++)
        {
            ManaUIComponent manaUIComponent = manaUIComponentList[i];
            CharacterBaseComponent characterBaseComponent = characterBaseComponentList[i];

            if (!manaUIComponent.gameObject.activeSelf) continue;

            manaUIComponent.ManaText.text = characterBaseComponent.Mana.ToString() + "/" + characterBaseComponent.ManaMax.ToString();
        }
    }

    private void AddComponentList(GameObject gameObject)
    {
        ManaUIComponent manaUIComponent = gameObject.GetComponent<ManaUIComponent>();
        CharacterBaseComponent characterBaseComponent = gameObject.GetComponent<CharacterBaseComponent>();

        if (manaUIComponent == null || characterBaseComponent == null) return;

        manaUIComponentList.Add(manaUIComponent);
        characterBaseComponentList.Add(characterBaseComponent);

        Initialize(manaUIComponent, characterBaseComponent);
    }

    private void RemoveComponentList(GameObject gameObject)
    {
        ManaUIComponent manaUIComponent = gameObject.GetComponent<ManaUIComponent>();
        CharacterBaseComponent characterBaseComponent = gameObject.GetComponent<CharacterBaseComponent>();

        if (manaUIComponent == null || characterBaseComponent == null) return;

        manaUIComponentList.Remove(manaUIComponent);
        characterBaseComponentList.Remove(characterBaseComponent);
    }
}
