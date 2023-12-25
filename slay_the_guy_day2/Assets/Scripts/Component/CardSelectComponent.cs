using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSelectComponent : MonoBehaviour
{
    private Vector3 basePosition;
    private Quaternion baseRotation;
    private Vector2 size;
    [SerializeField] private Vector3 positionOffset;

    public Vector3 BasePosition { get => basePosition; set => basePosition = value; }
    public Quaternion BaseRotation { get => baseRotation; set => baseRotation = value; }
    public Vector2 Size { get => size; set => size = value; }
    public Vector3 PositionOffset { get => positionOffset; set => positionOffset = value; }

}
