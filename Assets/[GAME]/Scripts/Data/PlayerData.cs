using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "CustomData/PlayerData")]
public class PlayerData : ScriptableObject
{
    public float Speed;
    public float RotationSpeed;
    public Vector2 HorizontalClamp;
}
