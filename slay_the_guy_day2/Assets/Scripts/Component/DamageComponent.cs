using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageComponent : MonoBehaviour
{
    private int damage;
    private bool isDamage;
    private int defense;

    public int Damage { get => damage; set => damage = value; }
    public bool IsDamage { get => isDamage; set => isDamage = value; }
    public int Defense { get => defense; set => defense = value; }
}
