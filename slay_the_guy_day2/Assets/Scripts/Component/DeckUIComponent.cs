using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DeckUIComponent : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI deckCountText;

    public TextMeshProUGUI DeckCountText { get => deckCountText; set => deckCountText = value; }
}
