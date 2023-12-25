using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyActionComponent : MonoBehaviour
{
    [SerializeField] private int defense;

    public int Defense { get => defense; set => defense = value; }
}
