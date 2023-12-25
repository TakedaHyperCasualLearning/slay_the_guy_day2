using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;

public class HitPointUIComponent : MonoBehaviour
{
    [SerializeField] TextMeshPro hitPointUI;

    public TextMeshPro HitPointUI { get => hitPointUI; set => hitPointUI = value; }
}
