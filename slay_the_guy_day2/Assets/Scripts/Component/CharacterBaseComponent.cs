using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBaseComponent : MonoBehaviour
{
    [SerializeField] private int hitPoint;
    private int hitPointMax;
    [SerializeField] private int attackPoint;
    [SerializeField] private int mana;
    private int manaMax;

    public int HitPoint { get => hitPoint; set => hitPoint = value; }
    public int HitPointMax { get => hitPointMax; set => hitPointMax = value; }
    public int AttackPoint { get => attackPoint; set => attackPoint = value; }
    public int Mana { get => mana; set => mana = value; }
    public int ManaMax { get => manaMax; set => manaMax = value; }
}
