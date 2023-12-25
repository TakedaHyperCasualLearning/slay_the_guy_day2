using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ManaUIComponent : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI manaText;

    public TextMeshProUGUI ManaText { get => manaText; set => manaText = value; }
}
