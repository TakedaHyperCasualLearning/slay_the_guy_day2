using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnEndButtonComponent : MonoBehaviour
{
    [SerializeField] Button turnEndButton;

    public Button TurnEndButton { get => turnEndButton; set => turnEndButton = value; }
}
