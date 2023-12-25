using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBaseComponent : MonoBehaviour
{
    [SerializeField] private int hitPoint;
    [SerializeField] private int hitPointMax;
    [SerializeField] private int attackPoint;

    public int HitPoint { get => hitPoint; set => hitPoint = value; }
    public int HitPointMax { get => hitPointMax; set => hitPointMax = value; }
    public int AttackPoint { get => attackPoint; set => attackPoint = value; }
}
