using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnComponent : MonoBehaviour
{
    private bool isMyTurn;
    private TurnState turnState;

    public bool IsMyTurn { get => isMyTurn; set => isMyTurn = value; }
    public TurnState TurnStatus { get => turnState; set => turnState = value; }
}
