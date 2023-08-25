using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "CustomData/PlayerData")]
public class PlayerData : ScriptableObject
{
    public float speed;
    public float rotationSpeed;
}
